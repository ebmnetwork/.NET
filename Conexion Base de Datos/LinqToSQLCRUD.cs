using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration; //Se debe de igual manera referenciar System.Configuration.dll


namespace TrabajandoConLinq
{
    class LinqToSQLCRUD
    {
        //LLamar la cadena de conexion Se debe tener en cuenta el parametro name del AppConfig

        string ctn = ConfigurationManager.ConnectionStrings["nameAppConfig"].ToString();

        public void InsertarLinqSql()
        {
            LinqToSqlDataContext db = new LinqToSqlDataContext(ctn);

            //Create new Employe
            TBL_EMPLOYEE empleado = new TBL_EMPLOYEE();
            Console.Write("Ingrese Nombre Empleado: ");
            empleado.EmployeeName = Console.ReadLine();
            Console.Write("Ingrese Email Empleado: ");
            empleado.EmployeeEmail = Console.ReadLine();
            Console.Write("Ingrese El Id del Departamento: ");
            empleado.DepartmenyId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese La direccion del empelado: ");
            empleado.EmployeeAddress = Console.ReadLine();
            Console.Write("Ingrese Contacto: ");
            empleado.EmployeeContact = Console.ReadLine();

            //Add new Employee to database
            db.TBL_EMPLOYEE.InsertOnSubmit(empleado);

            //Save changes to database
            db.SubmitChanges();

            //Get new Inserted Employee

            TBL_EMPLOYEE insertedEmployee = db.TBL_EMPLOYEE.FirstOrDefault(e => e.EmployeeName.Equals(empleado.EmployeeName));
            Console.WriteLine("Employee Id = {0}, Name = {1}, Email = {2}, ContactNo = {3}, Adress = {4}", insertedEmployee.EmployeeId, insertedEmployee.EmployeeName, insertedEmployee.EmployeeEmail, insertedEmployee.EmployeeContact, insertedEmployee.EmployeeAddress);

            Console.WriteLine("\nPress any key to exit program.");
            Console.ReadKey();

        }

        public void ActualizarLinqSql()
        {
            LinqToSqlDataContext db = new LinqToSqlDataContext(ctn);

            //get Employee for update
            int codigoEmpleado;
            Console.Write("Ingrese el Id De la persona que desea actualizar: ");
            codigoEmpleado = Convert.ToInt32(Console.ReadLine());

            TBL_EMPLOYEE empleado = db.TBL_EMPLOYEE.FirstOrDefault(e => e.EmployeeId.Equals(codigoEmpleado));

            Console.Write("Ingrese Nombre Empleado: ");
            empleado.EmployeeName = Console.ReadLine();
            Console.Write("Ingrese Email Empleado: ");
            empleado.EmployeeEmail = Console.ReadLine();
            Console.Write("Ingrese El Id del Departamento: ");
            empleado.DepartmenyId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese La direccion del empelado: ");
            empleado.EmployeeAddress = Console.ReadLine();
            Console.Write("Ingrese Contacto: ");
            empleado.EmployeeContact = Console.ReadLine();

    
            //Save changes to database
            db.SubmitChanges();

            //Get Updated Employee

            Console.Write("Los datos registrados son los siguientes: ");

            TBL_EMPLOYEE updateEmployee = db.TBL_EMPLOYEE.FirstOrDefault(e => e.EmployeeId.Equals(codigoEmpleado));
            Console.WriteLine("Employee Id = {0}, Name = {1}, Email = {2}, ContactNo = {3}, Adress = {4}", updateEmployee.EmployeeId, updateEmployee.EmployeeName, updateEmployee.EmployeeEmail, updateEmployee.EmployeeContact, updateEmployee.EmployeeAddress);

            Console.WriteLine("\nPress any key to exit program.");
            Console.ReadKey();

        }

        public void EliminarLinqSql()
        {

            LinqToSqlDataContext db = new LinqToSqlDataContext(ctn);

            //get Employee for update
            int codigoEmpleado;
            Console.Write("Ingrese el Id De la persona que desea Eliminar: ");
            codigoEmpleado = Convert.ToInt32(Console.ReadLine());

            TBL_EMPLOYEE deleteempleado = db.TBL_EMPLOYEE.FirstOrDefault(e => e.EmployeeId.Equals(codigoEmpleado));

            //Delete Employee
            db.TBL_EMPLOYEE.DeleteOnSubmit(deleteempleado);

            //Save changes to database
            db.SubmitChanges();


            //Get all Employee from database

            Console.Write("Listado de empleados: ");

            var listaEmpleados = db.TBL_EMPLOYEE;

            foreach (TBL_EMPLOYEE empleado in listaEmpleados)
            {
         
                Console.WriteLine("Employee Id = {0}, Name = {1}, Email = {2}, ContactNo = {3}, Adress = {4}", empleado.EmployeeId, empleado.EmployeeName, empleado.EmployeeEmail, empleado.EmployeeContact, empleado.EmployeeAddress);

            }
          
            Console.WriteLine("\nPress any key to exit program.");
            Console.ReadKey();

        }

    }
}
