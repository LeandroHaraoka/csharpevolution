# System.Text
O namespace System.Text tem como objetivo definir regras de codificação e decodificação de carateres ASCII e Unicode, entre cadeias de caracteres e bytes. As conversões e manipulações de caracteres contam com mecanismos que não implicam na instanciação de objetos do tipo String. 
No System.Text encontram-se classes que possuem métodos conversão de caracteres como Encoder/Decoder, classes que configuram tratamento de falhas de conversão e classes de encoding, onde são configuradas as regras das conversões.

É muito comum o uso de Encoding para codificar e decodificar sequências. Métodos como GetBytes codifica uma sequência de caracteres em uma sequência de bytes. Já métodos como GetChar realiza a decodificação, ou seja, o oposto
## Encoding
A classe Enconding representa regras de codificação de caracteres em bytes. No exemplo a seguir, uma string será codificada utilizando o Encondig do tipo Unicode. 

    var unicodeString = "This is a simple unicode string.";
    byte[] unicodeBytes = Encoding.Unicode.GetBytes(newString);

Para converter o resultado em outra codificação, pode-se utilizar o método Encoding.Convert, conforme abaixo, onde converte-se uma sequência de bytes em Unicode para ASCII.

    byte[] asciiBytes = Encoding.Convert(Encoding.Unicode, Encoding.ASCII, unicodeBytes);

## Encoder

A classe Encoder contém dois métodos importantes para codificação de caracteres, GetBytesCount e GetBytes. 
Primeiramente, para se obter uma instância do tipo Encoder, usa-se o método GetEnconder de um Encoding, conforme abaixo.

    Encoder encoder = Encoding.UTF7.GetEncoder();
A codificação é realizada da seguinte maneira.

    Byte[] destination = new Byte[encoder.GetByteCount(chars, 0, chars.Length, true)]; 
    encoder.GetBytes(chars, 0, chars.Length, destination, 0, true);
Na primeira linha, com auxílio do método GetByteCount, cria-se um array de bytes do tamanho da codificação resultante dos caracteres de chars.

 Na segunda linha, realiza-se a codificação propriamente dita. O método GetBytes recebe, respectivamente, a cadeia de caracteres, o índice de início da codificação, o número de caracteres a ser codificado, o destino, o índice do destino no qual se iniciará o resultado e o flush, que indica se o encoder descarta informações de estado.

## EncoderExceptionFallback

Quando passamos uma instância da classe EncoderExceptionFallback no construtor de um Encoding, definimos um mecanismo de tratamento de falha. Este mecanismo, denominado fallback, lança uma exceção quando se tenta codificar um caracter não suportado pelo encoding, no método GetBytes por exemplo.
A exceção carrega uma mensagem do tipo 

> System.Text.EncoderFallbackException: Unable to translate Unicode character *xpto* at index 0 to specified code page.
