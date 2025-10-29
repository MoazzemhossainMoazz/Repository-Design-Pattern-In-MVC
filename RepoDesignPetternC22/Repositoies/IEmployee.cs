using RepoDesignPetternC22.Models;

namespace RepoDesignPetternC22.Repositoies
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int EmployeeID);
        void Insert(Employee employee);
        void Update(Employee employee);
        void Delete(int EmployeeID);
        int Save();
    }

    public class EmployeeRepo : IEmployee
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepo(ApplicationDbContext context)
        {
            this._context = context;
        }
        public void Delete(int EmployeeID)
        {
            var emp = _context.Employees.Find(EmployeeID);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee GetById(int EmployeeID)
        {
            var emp = _context.Employees.Find(EmployeeID);
            return emp;
        }

        public void Insert(Employee employee)
        {
            _context.Employees.Add(employee);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
        }
    }
}
