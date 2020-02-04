# Generics
Generics introduzem o conceito de type parameters, que permitem especificar tipos para as classes e métodos no momento da declaração e inicialização deles.

Com o uso de generic types, permite-se criar classes e métodos reutilizáveis e evita-se erros de type conversion.

Podem ser do tipo genérico os fields, properties, indexers, constructors, events e finalizers.

## Constraints
O conceito de constraints permite atribuirmos regras para restringir o conjunto de possíveis type parameters declarados por um generic type.

    public static void Calculate<T>(IList<T> items) where T : IComparable

No exemplo acima, definimos um método genérico, onde o tipo T necessariamente implementa a interface IComparable.

Pode-se expandir o conceito de constraints para diversos tipos de restrição por exemplo:

 - Reference type constraint—where T : class 
 - Value type constraint—where
 - T : struct Constructor constraint—where T : new() 
 (The type argument must have a public parameterless constructor)
 - Conversion    constraint—where T : SomeType.

 
# Generics
Generics introduzem o conceito de type parameters, que permitem especificar tipos para as classes e métodos no momento da declaração e inicialização deles.

Com o uso de generic types, permite-se criar classes e métodos reutilizáveis e evita-se erros de type conversion. 

Podem ser do tipo genérico os fields, properties, indexers, constructors, events e finalizers.

## Constraints
O conceito de constraints permite atribuirmos regras para restringir o conjunto de possíveis type parameters declarados por um generic type.

    public static void Calculate<T>(IList<T> items) where T : IComparable

No exemplo acima, definimos um método genérico, onde o tipo T necessariamente implementa a interface IComparable.

Pode-se expandir o conceito de constraints para diversos tipos de restrição por exemplo:

 - Reference type constraint—where T : class 
 - Value type constraint—where
 - T : struct Constructor constraint—where T : new() 
 (The type argument must have a public parameterless constructor)
 - Conversion    constraint—where T : SomeType.

 ## Default
 O operador default é comumente utilizado com tipos genéricos para se retonar os valores default de um objeto de tipo desconhecido.

     T valor = default(T);
O código acima atribui o valor default do tipo T para a variável valor.

## Typeof
Quando trabalhamos com um tipo genérico T podemos acessar o tipo por meio do operador typeof como abaixo.
 
    public void Print<T>(T value)
    {
    	Console.WriteLine(typeof(T));
	    Console.WriteLine(value.GetType());
    }
No exemplo, as duas operações possuem o mesmo resultado.