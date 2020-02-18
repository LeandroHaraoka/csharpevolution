# Exceptions

A exception handling é uma maneira de controlar fluxos de erro previamente conhecidos ou não, que podem ser tratados em tempo de execução. Este mecanismo consiste em três blocos, que combinados entre si, podem proporcionar diversas formas de tratar uma exceção. Os blocos são try-catch-finally.

    static void Main(string[] args)
    {
    try
    {
	   int i = 10;
       int result = i / 0;
    }
    
    catch(DivideByZeroException ex) when (i >= 10)
    {
       LogError(ex);
    }
    catch(InvalidOperationException ex)
    {
       LogError(ex);
    }
    finally
    {
	    // Do nothing
    }
    }

Quando uma exceção é lançada, ela se propaga até encontrar uma bloco do tipo catch com o filtro de exceção correspondente. Exceções não capturadas são tratadas por uma rotina genérica proporcionada pelo sistema que apresenta uma caixa de diálogo.

O bloco Finally permite o programador liberar recursos externos sem a necessidade de esperar a execução do garbage collector. Por exemplo, um bloco finally pode atuar finalizando conexões de banco de dados, fechando streams de arquivos, etc.
 
 As exceções estão todas definidas no namespace System.Exceptions. Elas herdam da classe Exception. Todas possuem um propriedade do tipo string chamada StackTrace, que contém o nome dos métodos invocados na atual stack. Também possuem uma propriedade TargetSite que representa o método dentro do qual a exceção foi lançada.

Pode-se customizar exceções, criando classes que herdam o comportamento da Exception, como abaixo.

     public void Metodo()
    {
       if (xpto is null)
       {
          throw new MinhaExcecao("Mensagem da excecao");
       }
    }
    
    public class MinhaExcecao: Exception
    {
       public MinhaExcecao(string message)
          : base(message)
       {
       }
    }
O exemplo acima mostra o lançamento de uma exceção através da sintaxe throw. Essa sintaxe pode ser utilizada também para relançar uma exceção que já foi capturada dentro de um bloco catch. Porém existem duas maneiras. 

    catch(Exception ex)
    {
	    // Trata a excecao
	    throw; 
    }
    catch(Exception ex)
    {
	    // Trata a excecao
	    throw ex; 
    }
Quando lançamos uma exceção, salvamos a sua localização atual na pilha. No primeiro primeiro bloco, estamos relançando a exceção sem substituir o valor salvo da localização na pilha. No segundo, como lançamos a variável, estamos substituindo valor salvo, pela nova posição da pilha.

A classe Exception tem definido um método GetBaseException() que retorna a exceção mais interna (original). Em combinação com o ToString(), pode-se logar a exceção específica com o objetivo de facilitar o encontro de erros.