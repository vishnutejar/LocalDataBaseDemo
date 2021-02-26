using LocalDataBaseDemo.models;
using LocalDataBaseDemo.utiles;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalDataBaseDemo.database
{
    public class StudentDataBase
    {
       public StudentDataBase() {
            CreateStudentInfoTable();
        }
        static Lazy<SQLiteAsyncConnection> lazyDatabaseConnection = new Lazy<SQLiteAsyncConnection>(() =>
         {

             return new SQLiteAsyncConnection(Constance.DatabaseFilePathe);
         });

        public static SQLiteAsyncConnection Database = lazyDatabaseConnection.Value;

        private void CreateStudentInfoTable()
        {

            if (!Database.TableMappings.Any(m => m.TableName == typeof(StudentsInfo).Name))
            {
                Database.CreateTableAsync<StudentsInfo>();
            }
        }

        public Task<List<StudentsInfo>> GetStudentsAsync()
        {
            return Database.Table<StudentsInfo>().ToListAsync();
        }

        public Task<StudentsInfo> GetStudentByIdAsync(int id)
        {
            return Database.Table<StudentsInfo>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> InsertStudentsAsync(StudentsInfo item)
        {
            if (item.Id != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteStudentAsync(StudentsInfo item)
        {
            return Database.DeleteAsync(item);
        }

        public void UpdateStudentById(string id) { 
        
        }

    }


}
