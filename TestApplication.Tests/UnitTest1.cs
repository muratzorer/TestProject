using System;
using System.Collections.Generic;
using NUnit.Framework;
using MvcApplication;

namespace TestApplication.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void FetchEmployeesTest()
        {
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee() { EmpId = 1, Name = "Anderson", Salary = 2000 });
            empList.Add(new Employee() { EmpId = 2, Name = "Johnson", Salary = 3000 });
            empList.Add(new Employee() { EmpId = 3, Name = "Jackson", Salary = 4000 });

            Assert.That(EmployeeStore.FetchEmployees()[0].EmpId, Is.EqualTo(empList[0].EmpId));
            Assert.That(EmployeeStore.FetchEmployees()[0].Name, Is.EqualTo(empList[0].Name));
            Assert.That(EmployeeStore.FetchEmployees()[0].Salary, Is.EqualTo(empList[0].Salary));
        }
    }
}
