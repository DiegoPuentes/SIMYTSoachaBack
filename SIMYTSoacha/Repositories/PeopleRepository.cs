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
        Task<bool> PermissionAsync(int id);
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
            string encryptPass = Encrypt(people.Passcodes);

            People updatePeople = new People
            {
                Names = people.Names,
                Lnames = people.Lnames,
                DtypeId = people.DtypeId,
                DocumentType = people.DocumentType,
                Ndocument = people.Ndocument,
                SexId = people.SexId,
                Sex = people.Sex,
                DateBirth = people.DateBirth,
                UserTypeId = people.UserTypeId,
                UserType = people.UserType,
                UserName = people.UserName,
                Passcodes = encryptPass,
                Isdeleted = people.Isdeleted
            };

            _context.People.Update(updatePeople);
            await _context.SaveChangesAsync();
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
            /*
            byte[] key = Encoding.UTF8.GetBytes("lave_segura_32_bytes_de_largo_12345"); // Debe ser de 32 bytes
            byte[] iv = Encoding.UTF8.GetBytes("tu_iv_de_16_byte"); // Debe ser de 16 bytes

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(str)))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
            /*SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = null;
            StringBuilder stringBuilder = new StringBuilder();
            data = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < data.Length; i++) stringBuilder.AppendFormat("{0:x2", data[i]);
            string encryptedPass = stringBuilder.ToString();
            return encryptedPass;*/
        }

        public async Task<bool> PermissionAsync(int id)
        { 
            return await _context.UsersXPermissions
                .Where(s => s.UtypeId == id && s.PermissionId == 1 && !s.Isdeleted).AnyAsync();
        }
    }
}
