# Open Closed Principle

Uma entidade, seja uma classe ou um método, deve ser aberta para extensões e fechada para modificações. Em outras palavras, novos pré-requisitos não devem exigir novas alterações em entidades já implementadas. Deve-se permitir extender o comportamento de um sistema sem a necessidade de alterá-lo. Geralmente, o princípio envolve herança e polimorfismo.

No SRP, a sacada está em saber qual comportamento devemos decompor e encapsular. Já no OCP, é saber quais comportamentos serão abstratos para que os usuários da entidade implementem e quais comportamentos já terão sua implementação concreta.

Suponha a entidade Order neste exemplo.

    public class Order
    {
	    public Guid Id { get; set; }
	    public OrderType Type { get; set; }
	    public Product Product { get; set; }
    }
 Ainda temos uma classe de filtro para cada combinação de filtros.
 

    public class OrderFilters
    {
    	public List<Order> FilterByType(IEnumerable<Order> orders, OrderType type) => orders.Where(o => o.Type == type).ToList();
        
	    public List<Order> FilterById(IEnumerable<Order> orders, Guid id) => orders.Where(o => o.Id == id).ToList();
    }

Porém, para cada novo filtro precisaríamos adicionar um novo método, modificando a classe de filtros. Para atender o OCP poderíamos adicionar as abstrações.

    public interface ISpecification<T>
    {
    	bool isSatisfied(T item);
    }
    
    public  interface  IFilter<T>
    {
	    List<T> Filter(IEnumerable<T> entries, ISpecification<T> specification);
    }

As abstrações acima atendem qualquer conjunto de entidades que precisem ser filtradas em algum ponto da aplicação. No caso da nossa entitade Order implementaríamos as interfaces da seguinte maneira:

ISpecification:

    public class OrderTypeSpecification : ISpecification<Order>
    {
	    private readonly OrderType _type;

	    public OrderTypeSpecification(OrderType type)
	    {
		    _type  =  type;
	    }
	    
	    public bool isSatisfied(Order order) => order.Type == _type;
    }
   
IFilter:

    public class OrderFilter : IFilter<Order>
    {
        public List<Order> Filter(IEnumerable<Order> orders, ISpecification<Order> order) => orders.Where(o => specification.isSatisfied(o)).ToList();
    }

E o filtro é invocado assim:

    var orderFilter = new OrderFilter(); // poderia ter sido injetado.
    var filteredOrders = orderFilter.Filter(orders, new OrderTypeSpecification(OrderType.Sell));
