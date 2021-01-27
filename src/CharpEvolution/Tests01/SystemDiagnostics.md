# System Diagnostics
O namespace System.Diagnostics proporciona classes e atributos para manipulação de processos do sistema, gerenciamento de eventos, medidores de performance, ferramentas de debug.

## DebuggerDisplay 

O DebuggerDisplay é um atributo que personaliza a forma na qual um objeto tem o seu valor apresentado durante o processo de debug, sem a necessidade de sobrescrever o comportamento do método ToString(). Por exemplo:

    [System.Diagnostics.DebuggerDisplay("{Name} - {Age)"]  
    public class Pessoa
    {  
        public string Name { get; set; }  
        public int Age { get; set; }  
    }   
com o atributo, o valor do objeto pessoa poderá ser apresentado como "Leandro - 25". 

## Conditional Attribute
Um atributo condicional permite o desenvolvedor adicionar uma condição para que a execução de um método ocorra. No exemplo abaixo, o método é executado apenas em processo de Debug.

    [System.Diagnostics.Conditional("DEBUG")]  
    public static void DebugMethod()  
    {  
        Console.WriteLine("Execute Debug Method");  
    }  
