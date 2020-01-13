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
Quando passamos um tipo referência por valor para um método, realizamos uma cópia da referência. Quando realiza-se uma alteração no conteúdo do parâmetro dentro do método, a alteração se reflete no conteúdo da referência original fora do método, pois o parâmetro carrega o mesmo endereço de mémória que o argumento enviado pelo método "caller".
Porém, caso seja atribuído um novo endereço à variável dentro do método, as alterações deixarão de ser refletidas no conteúdo da referência original fora do método, pois alterou-se o endeço de memória da variável.
   

    private void Method(object parametro)  
    {  
        parametro.Xpto= 1; //Altera referência original.
        
		parametro = new Object();
        parametro.Xpto= 2; //Não altera referência original, pois atribuiu-se uma nova referência à variável.
    } 
    
## Passing a value/reference type by reference
Existem mais de uma maneira de se passar um tipo valor/referência por referência. É possível passar um tipo por referência através de modificadores de parâmetros como *in*, *out* e *ref*.

## Reference local variables
É muito comum copiarmos variáveis locais da seguinte maneira:

    Pessoa pessoa2 = pessoa1;

Porém, podemos realizar a seguinte operaçao:

    ref Pessoa pessoa2 = ref pessoa1;
    
A linha acima realiza uma cópia da referência da variável, e não do conteúdo da referência. Em alguns casos, pode-se ganhar performance considerável copiando a referência ao invés de copiar todo o seu conteúdo.

## Reference return

Um referece return consiste em um método que retorna uma referência de um objeto.

Limitações:

 - Não é possível retornar uma referẽncia nula. Porém, pode-se retornar uma referência cujo valor é nulo.
 - O tempo de vida do objeto deve exceder o tempo de vida do método. Portanto, deve-se retornar uma instância, um field estático ou um argumento que foi recebido pelo método. Pelo mesmo motivo, não se pode utilizar reference return em métodos assíncronos.

Nos exemplos abaixo, considere que o metodo retorna uma referência de um objeto do tipo Pessoa.


    public ref Pessoa Metodo() 
    {
	    var pessoa = new Pessoa();
	    return ref pessoa; 
    }
    
Quando passamos o retorno do método para uma local variable,  como na linha a seguir, estamos criando uma nova variável que contém a refêrencia retornada.  

    Pessoa pessoa = Metodo();
Porém, podemos passar o resultado para uma reference local variable, conforme abaixo. Quando fazemos isso, estamos fazendo com que a variável pessoa seja apenas um alias para o retorno do método.

    ref Pessoa pessoa = ref Metodo();
No primeiro caso, se alterarmos a variável pessoa, o conteúdo interno do método não é alterado. Já no segundo, alterando a variável pessoa, estamos alterando diretamente a variável interna ao método, dado que pessoa é apenas um alias para ela.