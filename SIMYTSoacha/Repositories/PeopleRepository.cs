using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface IPeopleRepository
    {
        Task<IEnumerable<People>> GetAllPeopleAsync();
        Task<People> GetSubjectByIdAsync(int id);
        Task<People> CreatePeopleAsync(string name, string lnames, int dtypeid, string ndocument,
            int sex, DateTime date, int utypeid, string user, string password, bool isdeleted);
        Task UpdatePeopleAsync(People people);
        Task SoftDeletePeopleAsync(int id);
        Task<People> LoginAsync(string user, string pass);
        Task<bool> PermissionAsync(int id, int id2);
    }
    public class PeopleRepository : IPeopleRepository
    {
        private readonly SimytDbContext _context;
        public PeopleRepository(SimytDbContext context)
        {
            _context = context;
        }
        public async Task<People> CreatePeopleAsync(string name, string lnames, int dtypeid, string ndocument,
        int sex, DateTime date, int utypeid, string user, string password, bool isdeleted)
        {
            string encryptedPass = Encrypt(password);

            People people = new People
            {
                Names = name,
                Lnames = lnames,
                DtypeId = dtypeid,
                DocumentType = null, // Asignar instancia de DocumentsTypes
                Ndocument = ndocument,
                SexId = sex,
                Sex = null, // Asignar instancia de Sex
                DateBirth = date,
                UserTypeId = utypeid,
                UserType = null, // Asignar instancia de UsersTypes
                UserName = user,
                Passcodes = encryptedPass,
                Isdeleted = isdeleted
            };

            _context.People.Add(people);
            await _context.SaveChangesAsync();
            return people;
        }


        public async Task<IEnumerable<People>> GetAllPeopleAsync()
        {
            return await _context.People
                .Where(s => !s.Isdeleted)
                .ToListAsync();
        }
        public async Task<People> GetSubjectByIdAsync(int id)
        {
            return await _context.People
                .FirstOrDefaultAsync(s => s.PeopleId == id && !s.Isdeleted);
        }

        public async Task<People> LoginAsync(string user, string pass)
        {
            string encryptedPass = Encrypt(pass);

            return await _context.People.
                Where(s => user == s.UserName && encryptedPass == s.Passcodes)
                .FirstOrDefaultAsync(); 
        }

        public async Task SoftDeletePeopleAsync(int id)
        {
            var subject = await _context.People.FindAsync(id);
            if (subject != null)
            {
                subject.Isdeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdatePeopleAsync(People people)
        {
            _context.People.Update(people);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> PermissionAsync(int id, int id2)
        { 
            return await _context.UsersXPermissions
                .Where(s => s.UtypeId == id && s.PermissionId == id2 && !s.Isdeleted).AnyAsync();
        }

        public static string Encrypt(string str)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convertir la cadena de texto en un arreglo de bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(str));

                // Convertir los bytes a una cadena de texto hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }

        }
    }
}
