## Static Modifier

O modificador static, quando aplicado em membros de uma classe, torna eles acessíveis através da própria classe e não através de uma instância dela. Quando aplicado na classe, ele define a classe como não instânciável.

### Classe estática

Dado que a classe estática não é instanciável, não é possível definir construtores de instância para ela. Porém, pode-se definir construtores estáticos, que são privados e invocados uma única vez quando a aplicação é carregada. Uma vez carregada pela CLR, a classe permanece na memória pelo período de vida da aplicação.

Uma classe estática não pode ser herdada, portanto ela tem o comportamento de **sealed**.  

A classe estática é utilizada quando a classe não tem necessidade de estados internos.
 
### Membro estático 

Pode-se definir uma método estático tanto em classes de instância como em classes estáticas.  No caso de classes de instância, o membro estático é único para todas as instâncias da classe.

Um método de uma classe estática não é um método de uma instância. É um método que não leva em consideração o estado interno da classe e tem uma responsabilidade que não é a mesma da classe ao qual ele está vinculado.

### Construtor estático

O construtor estático é único e é utilizado para manipular processos de instanciação da classe que devem acontecer uma única vez ao longo da vida da aplicação. Caso o construtor estático encontre um erro, lança-se uma exception do tipo TypeInitializationException.

Um field do tipo static readonly pode apenas ser atribuído em um construtor estático ou como parte de sua declaração (na declaração do field que fica na classe). É preferível atribuí-lo em sua declaração, a fim de otimizar performance.