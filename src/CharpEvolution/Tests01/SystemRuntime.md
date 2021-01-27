# SystemRuntime
O namespace System.Runtime contém classes que auxiliam o gerenciamento de memória da aplicação, como GCSettings e MemoryFallPoint.

## GCSettings
GCSettings especifica a configuração do garbage collector do atual processo.

### IsServerGC
Indica se o Garbage Collector está ativo.

### LatencyMode
Define o modo de operação do GarbageCollector. Esta propriedade do GCSettings permite o desenvolvedor gerenciar o processamento do GC. Em processos críticos, pode-se definir o LatencyMode como LowLatency, com o intuito de liberar processamento. Após o término ou a redução da criticidade do processo, pode-se retornar o valor do LatencyMode. Os possíveis valores são definidos no enumerador *System.Runtime.GCLatencyMode*.

## MemoryFailPoint
MemoryFailPoint permite a aplicação validar se possui memória suficiente antes de executar uma ação. Esta classe recebe um inteiro em seu construtor que representa o valor em MBs do processo. Caso o valor seja superior ao disponível em memória, uma exceção do tipo *InsufficientMemoryException* é lançada.