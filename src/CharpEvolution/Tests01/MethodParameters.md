# Method Parameters

Existem diversas maneiras de se passar um parâmetro para um método. Deve-se escolher a forma mais apropriada de acordo com o comportamento desejado para a conteúdo dos argumentos e dos parâmetros formais.

## Named Parameters
A forma mais comum de se passar os argumentos de uma função é na ordem em que os parâmetros são definidos. Porém, pode-se passar o nome e o valor de cada um dos argumentos, sem a necessidade de ordenação.

    private void Method(bool status, string message)  
    {  
        //do something    
    } 
    
    static void Main(string[] args)  
    {  
       Method(status: true, message: "Message!");  
    }  

## Default/Optional Parameters
Caso o valor de algum parâmetro seja opcional, pode-se atribuir um valor default quando o argumento não é passado na invocação do método. Via de regra, o parâmetros opcionais devem ser assinados após os parâmetros obrigatórios.
   
    private void Method(bool status, string message = "New Message")  
    {  
        //do something    
    } 
    
    static void Main(string[] args)  
    {  
       Method(true);  
    } 

## Params Keyword
Quando utilizada a palavra-chave *params* indica-se que o método recebe uma quantidade maior ou igual a zero de parâmetros de um mesmo tipo. Cada um dos argumentos deve ser passado para o método separado por vírgula.

     private void Method(bool status, string message = "New Message")  
    {  
        //do something    
    } 
    
    static void Main(string[] args)  
    {  
       Method(true);  
    } 


## Passing parameters by value
Os parâmetros podem ser passados de duas maneiras: por valor ou via referência. Por default, eles são passados por valor.

### Passing a value type by value
Quando passamos um tipo valor por valor para um método, realizamos uma cópia do conteúdo que, dentro do método, será manipulada sem que haja alterações no conteúdo original. Ou seja, o conteúdo do argumento que foi definido pelo método "caller" não é alterado, mas o conteúdo do parâmetro do método "called" é alterado.

### Passing a reference type by value
Quando passamos um tipo referência por valor para um método, realizamos uma cópia da referência. Quando realiza-se uma alteração no conteúdo do parâmetro dentro do método, a alteração se reflete fora do método, no conteúdo da referência original, pois o parâmetro carrega o mesmo endereço de mémória que o argumento enviado pelo método "caller".
Porém, caso seja atribuído um novo endereço à variável dentro do método, as alterações deixarão de ser refletidas apenas dentro do método e não mais na referência original, pois alterou-se o endeço de memória da variável.
   
    private void Method(object parametro)  
    {  
        parametro.Xpto= 1; //Altera referência original.
        
		parametro = new Object();
        parametro.Xpto= 2; //Não altera referência original, pois atribuiu-se uma nova referência à variável.
    } 

## Passing parameters by reference

### Passing a value/reference type by reference
Existem mais de uma maneira de se passar um tipo valor/referência por referência. É possível passar um tipo por referência através de modificadores de parâmetros como *in*, *out* e *ref*.

Quando passamos um tipo valor via referência, estamos passando o endereço de memória que contém os dados do argumento. Caso seja realizada alguma alteração dentro do método, o conteúdo original de fora também é alterado, pois ambos compartilham o mesmo endereço de memória. 

O mesmo acontece quando passamos via referência. Se passarmos um tipo referência via referência e, dentro do método, alocarmos um novo objeto no parâmetro, o conteúdo original de fora também será alterado, pois ambos compartilham o mesmo endereço de memória.

#### ref
A keyword *ref* é utilizada na assinatura e na invocação do método que recebe um parâmetro via referência.  É obrigatório inicializar o argumento que será passado.

    public void Metodo(ref int argumento) 
    { 
	    argumento += 1; 
    }
    
    int number = 1; 
    Metodo(ref number);

Quando passamos um tipo valor por referência, estamos passando um ponteiro que aponta para o valor. Caso o parâmetro sofra modificação dentro do escopo método, a alteração será refletida na variável fora deste escopo. 

Quando passamos um tipo referência por referência, estamos passando o endereço de memória no qual o objeto está armazenado. Caso, dentro do escopo do método, o valor do parâmetro seja modificado para um outro endereço de memória, tal alteração se refletirá fora do escopo.

#### out
A keyword também pode ser utilizada para passar parâmetros via referência. A diferença em relação a *ref* é a não obrigatoriedade de inicialização do argumento fora do método.

    public void Metodo(out int argumento) 
    { 
	    argumento = 10; 
    }
    
    Metodo(out int number);
    // Apos execucao do metodo, number sera igual a 10.

#### in
A terceira forma de passarmos um argumento via referência é através da keyword *in*. A diferença em relação a *ref* é a que não se pode alterar de dentro do método o conteúdo do parâmetro. 
No caso do tipo valor, não se pode alterar o valor alocado no endereço do parâmetro. No caso do tipo referência, não se pode alocar uma nova referência no endereço do parâmetro.  

Ex: Tipo Valor

    int number = 1;
    Metodo(number); 

    public void Metodo(in int number) 
    { 
	    number = 2; // Gera erro
    }

Ex: Tipo Referência

    Pessoa p = new Pessoa { Name = Maria };
    Metodo(p); 
    
    public void Metodo(in Pessoa p) 
    { 
	    p.Name = Jose; // Nao gera erro
	    p = new Pessoa(); // Gera erro
    }

#### Limitações

Não é possível usar ref, in e out em métodos assíncros e nem em métodos que possuem yield return ou yield break.

#### Resumo

*ref*: utilizar em métodos que **possam alterar o conteúdo** do parâmetro.
*out*: utilizar em métodos que **devem inicializar** o parâmetro.
*in*: utilizar em métodos que **não possam alterar o conteúdo** do parâmetro.