
# SystemIO

O namespace System.IO é constituído de classes que fornecem ferramentas para gerenciamento de fluxo de dados. Tais fluxos podem ser do tipo leitura e escrita de arquivos, transferência de dados em rede e troca de dados em memória. Para cada categora de fluxo de dados existem classes responsáveis pelo gerenciamento, como FileStream, NetworkStream e MemoryStream. Estas classes herdam comportamentos da classe abstrata Stream, que define propriedades e métodos pertinentes ao fluxo de dados. Além disso, existem algumas classes que herdam de Stream que fornecem extensões às funcionalidades básicas.

## DirectoryInfo

A classe DirectoryInfo fornece métodos de instância para manipulação de diretórios. Cria-se uma instância passando-se o path no construtor do objeto. 

    var  dir  =  new  DirectoryInfo("C:\\Users\\name\\Downloads");

Um DirectoryInfo contém funções de criar, mover e deletar, por exemplo. Também existem métodos que retornam os subdiretórios e arquivos contidos no path fornecida na instanciação do objeto, conforme no exemplo abaixo.

     var  dir  =  new  DirectoryInfo("C:\\Users\\name\\Downloads");

    dir.GetFiles();
    dir.GetDirectories();
	dir.EnumerateFiles();
    dir.EnumerateDirectories();
    
Neste caso, os métodos "get" retornam arrays de FileInfo ou DirectoryInfo. Já  os métodos "Enumerate" retornam Enumerables de FileInfo e DirectoryInfo.

## Directory versus DirectoryInfo
A classe Directory possui funções com o mesmo propósito das funções de DirectoryInfo, porém estáticas. 

Isto quer dizer que, por não ser instanciável, esta classe tem uso mais apropriado para cenários que desejamos realizar poucas e simples manipulações. Por exemplo, podemos usar Directory para realizar uma simples deleção.

Por outro lado, se desejamos realizar diversas operações em um mesmo path, é mais adequado trabalharmos com uma instância de DirectoryInfo. Por exemplo, em um cenário onde queremos realizar operações de criação, mover, listagem de arquivos e subdiretórios, deleções, todas em um mesmo path. 

## File versus FileInfo
As classes File e FileInfo proporcionam métodos com o propósito de prover manipulação de arquivos. Da mesma forma que acontece para diretórios, a manipulação de arquivos pode ser realizada com métodos de instância, via objetos FileInfo, ou com métodos estáticos, via classe File.

## Iterando em uma árvore de diretórios

Para obter todos diretórios e subdiretórios contidos em um path, pode-se utilizar o seguinte comando. 

    root.GetDirectories("*.*", System.IO.SearchOption.AllDirectories);

A desvatagem desse comando é que, caso ocorra um DirectoryNotFoundException ou um UnauthorizedAccessException, a busca de todos os diretórios falhará. Para evitar isso, pode-se iterar manualmente, tratando as exceções pontualmente. O exemplo mostrará uma abordagem por meio de pilha.

```
public class StackBasedIteration
{
    static void Main(string[] args)
    {
        TraverseTree(args[0]);
        Console.WriteLine("Press any key");
        Console.ReadKey();
    }

    public static void TraverseTree(string root)
    {
        Stack<string> dirs = new Stack<string>(20);

        if (!System.IO.Directory.Exists(root))
            throw new ArgumentException();

        dirs.Push(root); // Adiciona o diretorio raiz.

        while (dirs.Count > 0)
        {
            string currentDir = dirs.Pop(); // 
            string[] subDirs;
            try
            {
                subDirs = System.IO.Directory.GetDirectories(currentDir);
            }

            catch (UnauthorizedAccessException e)
            {                    
                Console.WriteLine(e.Message);
                continue;
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }

            string[] files = null;
            try
            {
                files = System.IO.Directory.GetFiles(currentDir);
            }

            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
            
            foreach (string file in files)
            {
                try
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(file);
                    Console.WriteLine("{0}: {1}, {2}", fi.Name, fi.Length, fi.CreationTime);
                }
                catch (System.IO.FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }

            foreach (string str in subDirs)
                dirs.Push(str);
        }
    }
}
```