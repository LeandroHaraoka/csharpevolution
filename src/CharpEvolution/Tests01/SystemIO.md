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


