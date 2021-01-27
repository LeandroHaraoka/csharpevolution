# SystemGlobalization
O namespace System.Globalization é composto por classes que personalizam idiomas, calendários, moedas, formatação de datas, horários e números. Estas configurações definem o que chamamos de Cultura que é representada pela classe CultureInfo.

## CultureInfo
Pode-se instanciar uma CultureInfo de diversas maneiras. A mais comum é passar no construtor o nome do país e idioma.

    CultureInfo enUs = new CultureInfo("en-US");
A mesma CultureInfo poderia ter sido inicializada passando-se o LCID (LoCale ID) da cultura.

    CultureInfo enUs = new CultureInfo(1033);

### GetCultures
A classe CultureInfo possui um método estático que retorna uma lista de todas as culturas que possuem determinado tipo.

    CultureInfo[] specificCultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
    CultureInfo[] specificCultures = CultureInfo.GetCultures(CultureTypes.NeutralCultures);
No exemplo, SpecificCultures incluem as culturas atreladas ao par País-Idioma. Já as NeutralCultures são as culturas definidas apenas pelo idioma.

### DateTimeFormat
A propriedade DateTimeFormat permite personalizar como as datas e tempos serão apresentados.

Por exemplo, o código abaixo altera o identificador de horários "Ante Meridiem" para "a.m" ao invés do valor default "AM".

    CultureInfo myCI = new CultureInfo("en-US");
    myCI.DateTimeFormat.AMDesignator = "a.m.";

No exemplo abaixo, as datas serão apresentadas como MM-dd-YYYY ao invés do padrão MM/dd/YYYY, pois o separador foi definido como "-".

    CultureInfo myCI = new CultureInfo("en-US"); 
    myCI .DateTimeFormat.DateSeparator = "-";
    
### NumberFormat
Assim como na formatação de datas, pode-se definir padrões para a formatação de números. 
Através da propriedade *currentInfo.NumberFormat.NumberGroupSeparator* definimos o separador dos milhares e através de *currentInfo.NumberFormat.NumberDecimalSeparator* definimos o separador dos decimais. A propriedade NumberFormat também nos proporciona informações sobre a moeda da cultura. Pode-se obter, por exemplo, o símbolo da moeda acessando currentInfo.NumberFormat.CurrencySymbol.