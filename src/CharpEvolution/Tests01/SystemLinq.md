# System.Linq

O System.Linq (Language Integrated Query) é um namespace que contém métodos de extensão para consultas em objetos que implementam a interface IEnumerable<T>. Os métodos são fornecidos pela classe estática Enumerable para objetos que implementam IEnumerable e pela classe Queryable para objetos que implementam IQueryable. Quando retornam uma sequência de valores, eles realizam o processamento dos dados apenas quando o resultado é enumerado.

Um exemplo de método do namespace Linq é o First. Este método, como dito anteriormente, se encontra na classe estática Enumerable, como segue. A função atua em um objeto que implementa a interface Linq.

    namespace System.Linq
	{   
	    public static class Enumerable
	    {
		    public  static TSource First<TSource> (this System.Collections.Generic.IEnumerable<TSource> source);
	    }
    }
