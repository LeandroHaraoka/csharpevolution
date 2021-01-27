# Dependency Inversion Principle

O princípio de inversão de dependências estabele que módulos de alto níveis não devem depender de módulos de baixo níveis, mas ambos devem depender de abstrações. 

Módulos de alto nível são aqueles que possuem natureza abstrata e contam com lógica mais complexa, são os módulos que orquestram os de baixo nível. Módulos de baixo nível são aqueles focados em detalhes da aplicação e contam com funcionalidades mais específicas. A existência de uma abstração entre eles tornam os módulos não dependentes de implementações e, consequentemente, menos acoplados.

Além disso, as abstrações não devem ser dependentes de detalhes (entidades concreta), mas sim o contrário.

    public enum Gender
    {
    	Male,
    	Female
    }

    public enum Position
    {
    	Administrator,
    	Manager,
    	Executive
    }

    public class Employee
    {
    	public string Name { get; set; }
    	public Gender Gender { get; set; }
    	public Position Position { get; set; }
    }

    public class EmployeeManager
    {
	    private readonly List<Employee> _employees;
   	    public  List<Employee>  Employees  =>  _employees;
   	    
	    public EmployeeManager()
	    {
		    _employees = new List<Employee>();
	    }
    
	    public void AddEmployee(Employee employee)
	    {
		    _employees.Add(employee);
	    }
    }

    public class EmployeeStatistics
    {
	    private  readonly  EmployeeManager _empManager;
	    
	    public  EmployeeStatistics(EmployeeManager empManager)
	    {
		    _empManager  =  empManager;
	    }
    
	    public  int  CountFemaleManagers()
	    {
		    _empManager.Employees.Count(emp  =>  emp.Gender  ==  Gender.Female  && emp.Position == Position.Manager);
	    }
    }

Essa implementação atende a funcionalidade desejada. Porém, acoplamos o módulo de alto nível EmployeeStatistics com o de baixo nível EmployeeManager, ou seja, instâncias de EmployeeStatistics dependem de uma classe do tipo EmployeeManager. Além disso, estamos expondo os Employees da EmployeeManager para a classe EmployeeStatistics, o que resulta em EmployeeManager perder o controle dos seus Employees.

Para atender o Princípio de Inversão de Dependências, pode-se seguir a implementação abaixo.

	   public interface IEmployeeSearchable
	   {
	       IEnumerable<Employee> GetEmployeesByGenderAndPosition(Gender gender, Position position);
	   }
	   
	   public class EmployeeManager: IEmployeeSearchable
	   {
	       private readonly List<Employee> _employees;
	    
	       public EmployeeManager()
	       {
	           _employees = new List<Employee>();
	       }
	       
	       public void AddEmployee(Employee employee)
	       {
	           _employees.Add(employee);
	       }
	    
	       public IEnumerable<Employee> GetEmployeesByGenderAndPosition(Gender gender, Position position)
	           => _employees.Where(emp => emp.Gender == gender && emp.Position == position);
	   }
    
	   public class EmployeeStatistics
	   {
	       private readonly IEmployeeSearchable _emp;
	    
	       public EmployeeStatistics(IEmployeeSearchable emp)
	       {
	           _emp = emp;
	       }
	    
	       public int CountFemaleManagers() => 
	       _emp.GetEmployeesByGenderAndPosition(Gender.Female, Position.Manager).Count();
	   }
A interface adicionada permite a EmployeeStatistics trabalhar com uma abstração, desacoplando ela de qualquer classe concreta. Além disso, a EmployeeManager não precisa expor suas lista de Employees.

O exemplo, em resumo, além de desacoplar classes de níveis diferentes por meio de uma abstração, substituiu a exposição do campo da classe do nível baixo por uma abstração que fornece o valor de tal campo, o que garante acesso ao valor mas não permite alterá-lo. 