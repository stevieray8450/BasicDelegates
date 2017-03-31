using System;
using System.Collections.Generic;

namespace BasicDelegates
{
	// this delegate will return "true" or false"
	// for the passed in employee
	delegate bool isPromotable(Employee empl);

	class Employee
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public Gender gender { get; set; }
		public int Experience { get; set; }

		// the delegate has to be passed in as a parameter.
		// this delegate will point to a function
		public static void PromoteEmployee(List<Employee> employeeList, isPromotable isEligibleToPromote)
		{
			foreach (Employee emp in employeeList)
			{
				// the passed in delegate is being  thrown in for the condition	
				if (isEligibleToPromote(emp))
				{
					Console.WriteLine("{0} promoted", emp.Name);
				}
			}
		}
	}

	public enum Gender
	{
		Unknown,
		Male,
		Female
	}

	class MainClass
	{
		public static void Main(string[] args)
		{
			List<Employee> empList = new List<Employee>();
			empList.Add(new Employee() { ID = 101, Name = "Steve", gender = Gender.Male, Experience = 5 });
			empList.Add(new Employee() { ID = 102, Name = "James", gender = Gender.Male, Experience = 3 });
			empList.Add(new Employee() { ID = 103, Name = "Kim", gender = Gender.Female, Experience = 7 });


			// instantiating the delegate as "promotable"
			// note that the function it points to is taken in as a parameter
			isPromotable promotable = new isPromotable(Promote);
			Employee.PromoteEmployee(empList, promotable);
		}

		// this method returns a boolean
		// note that the signatures of this method and the delegate (at the top of this code)
		// are the same
		// note, also, that it takes in an Employee object
		public static bool Promote(Employee emp)
		{
			if (emp.Experience >= 5)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}