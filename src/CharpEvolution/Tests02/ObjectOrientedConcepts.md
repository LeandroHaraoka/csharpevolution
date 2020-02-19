## Classes

Em programação orientada a objetos, uma classe representa a definição de características e funcionalidades como properties, fields, events e methods. Essa definição é utilizada quando queremos criar e manipular um objeto. 

## Objects

Um objeto é uma instancia de uma classe ou de uma struct alocada e configurada na memória da aplicação. Um objeto instanciado a partir de uma classe é alocado na região de memória HEAP. Já um objeto instanciado a partir de uma struct é alocado na região de memória Stack.

## Métodos protected

Os métodos protected são aqueles que podem ser invocados apenas pela classe onde estão ou por classes que herdam ela, através da keywork *this*. Eles não podem ser invocados a partir de instâncias das classes onde estão. 

## Classes sealed

As classes sealed são aquelas que não podem ser herdadas. Isso significa que elas podem apenas serem instanciadas. Como não há herança, não é possível sobreescrever o comportamento dos seus métodos, o que reforçar o encapsulamento dos métodos da classe.

## Encapsulamento
 
 O encapsulamento tem como objetivos proteger atributos e métodos de uma classe ou struct a fim de evitar alterações acidentais em seus comportamentos. Ele permite que modificações sejam realizadas por meio apenas do métodos específicos para isso. O nível de acesso aos fields, properties e methods de uma classe ou de uma struct pode ser configurado via modificadores de acesso public, private, protected, etc. 

Por exemplo, quando a manipulação do valor de uma property ou um field não deve ser exposta para fora da classe/struct, torna-se a property ou field privado e configura-se o respectivo comportamento nos métodos get e set ou no construtor.

O encapsulamento é fundamental para expor apenas aquilo que interessa para o público. 

## Classes abstratas
 
Classes abstratas são aquelas que não podem ser instanciadas mas podem ser herdadas. Sâo comumente utilizadas como base classes, contendo métodos que podem ou não serem implementados.

Por exemplo, posso ter uma base class abstrata Mamífero, que implementa um método Alimentar(). Uma outra classe Baleia, pode herdar a classe abstrata, dado que Baleia é um Mamífero, e implementar o método Alimentar(), sem a necessidade de sobrescrita dessa função.

Uma classe abstrata não pode ser estática, não pode ser sealed e nem herdar de outra abstrata.

## Herança

A herança consiste em uma classe herdar atributos e métodos de uma outra classe bae ou interface, extendo a funcionalidade original. 

A herança a partir de base classes deve-se utilizá-la em cenários onde uma classe derivada possui relacionamento do tipo **é um** com a base class. É importante refletir se o uso de herança é realmente desejado, pois ela gera forte acomplamento entre as classes.

## Abstract property

Uma classe abstrata pode conter properties abstratas, que são aquelas que não possuem implementação dos métodos get e set, mas exigem que as classes derivadas implementem, através o override.

    public abstract class Shape
    {
        public string Id { get; set; }
        public abstract double Area { get; }
    }
    
    public  class  Square : Shape
    {
	    public  override  double Area 
	    { 
		    get 
		    { 
			    return xpto; 
		    } 
	    }
    }

## Abstract method
 
Uma classe abstrata pode contem métodos abstratos. São métodos que não possuem implementação conhecida, mas assinatura sim. Eles são assinados como abstratos e na implementação utiliza-se o override.

    abstract  class test1 
    {
    	public  int add(int i, int j) 
    	{
		    return i + j;
	    }

	    public  abstract  int mul(int i, int j);
    }
    
    class test2: test1 
    {
	    public override int mul(int i, int j) 
	    {
		    return i * j;
	    }
    }

## Mofidificador new e override

O modificador new é utilizado para *esconder* atributos e métodos em uma classe derivada. Quando utilizado, ele cria um novo atributo ou método com mesmo nome/assinatura e *esconde* a implementação original.

Já o override, extende a funcionalidade implementada na base class. Por exemplo, considere três variáveis: 

 - uma do tipo base instanciada a partir da base class
 - uma do tipo derived instanciada a partir da derived 
 - uma do tipo base instanciada a partir da derived (para essa que vamos olhar)

Segue código:

    class  BaseClass 
    { 
	    public virtual void Metodo() 
	    { 
	    Console.WriteLine("Base"); 
	    } 
    } 

	class  DerivedClass : BaseClass 
	{ 
		// public new void Metodo()
		// public override void Metodo() 
		{ 
			Console.WriteLine("Derived"); 
		} 
	}
	
    BaseClass bc = new BaseClass();  
    DerivedClass dc = new DerivedClass(); 
    BaseClass bcdc = new DerivedClass();
    bc.Metodo();
    dc.Metodo();
    bcbc.Metodo();

Com a sobrescrita utilizando o modificador new, o resultado seria:
> Base 
> Derived 
> Base

Com a sobrescrita utilizando o modificador override, o resultado seria:
> Base 
> Derived 
> Derived

Para utilizar o modificador override é necessário que a classe que estamos herdando possua a definição do método modificada para virtual ou abstract. 

## Modificador virtual

Para possibilitar a sobrescrita por meio o override em classes derivadas, é necessário que o atributo ou o método da base class possua o modificado virtual. Diferentemente do modificador abstract, o modificador virtual é utilizado para cenários onde existem uma implementação default que é definida na base class. Ele também difere do abstract por se utilizado em classes não abstratas.

Em uma árvore de heranças, o modificador virtual é herdado. Por exemplo:

    public  class  A 
    { 
		public virtual void DoWork() 
		{ 
		} 
	} 
	
    public  class  B : A 
    { 
	    public override void DoWork() 
	    { 
	    }
    }
    
    public  class  C : B 
    { 
	    public sealed override void DoWork() 
	    { 
	    } 
    }
    
    public  class  D : C 
    { 
	    public new void DoWork() 
	    {
	    }
	}

Como em A DoWork é virtual, B consegue sobreescrever. 
Como dito anteriormente, o modificador virtual se propaga na herança, então C também pode sobreescrever DoWork com override. 
Porém, em C usa-se **sealed virtual**, o que interrompe a propagação do modificador virtual na herança. 
Em D, não é possível sobreescrever por meio de override, mas pode-se utilizar o modificador new.

## Polimorfismo

Polimorfismo é o príncipio pelo qual classes derivadas de uma mesma base class podem invocar métodos que possuem a mesma assinatura, mas que o comportamento difere e é específico para cada classe derivada.

