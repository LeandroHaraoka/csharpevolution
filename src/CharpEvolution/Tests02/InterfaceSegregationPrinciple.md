# Interface Segregation Principle

Nas classes que implementam interfaces não deve existir implementação de métodos que não são utilizados. As interfaces devem ser enxutas o suficiente para que não seja necessário implementar tais comportamentos desnecessários.

Quando ferimos o ISP, podemos por consequência ferir também o LSP. Os métodos que não não são utlizados podem contar com implementações do tipo NotImplementMethod ou UnsupportedOperationException. Neste caso, estaríamos restringindo a funcionalidade do contrato base da interface e um design deste tipo estaria gerando erros para na implementação.

Quando o ISP não é seguido podemos também estar fugindo do SRP. Em um contrato que possui métodos não relacionados ou inadequadamente acoplados, estamos gerando múltiplos pontos de alteração na interface, um ponto de mudança para cada membro não relacionado.