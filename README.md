
# Sorgu Filtreleme ve Sayfalama

Bu proje, C# programlama dilini kullanarak ASP.NET Core veya ASP.NET MVC gibi web uygulamaları geliştirmek için Action Filter'ları kullanarak, veri sorgularını filtreleme ve sonuçları sayfalama yeteneklerine sahip bir uygulama geliştirmeyi amaçlar. Bu proje, kullanıcıların veri kaynakları üzerinde etkili bir şekilde sorgu yapmalarına, sonuçları filtrelemelerine ve sayfalandırmalarına imkan tanır.
## Özellikler

- Action Filter ile sayfalama ve filtreleme
- BuildFilterExtension ile string'ten expression oluşturma
  
## API Kullanımı

#### Tüm öğeleri getir

```http
  GET /Home/GetAll
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `Paging` | `string` | **[FromQuery]** Paging |

```http
?Paging={"PageNumber":1,"PageSize":10,"Filters":[{"field":"Name","operator":"contains","value":"1"},{"field":"Name","operator":"contains","value":"2"}],"logic":"or"}
```

'Name' alanının içinde '1' içeren yada 'Name' alanının içinde '2' içeren verilerin 10 satırlık ilk (1.) sayfasını döner.
  
## Ekran Görüntüleri

```http
  GET /Home/GetAll
```
![filtrelenmemiş](https://github.com/ufukgulec/PaginationWithActionFilter/assets/51711890/1b41ba9a-9b5c-455d-9f38-f9d7a98ac56c)

```http
  GET /Home/GetAll?Paging={"PageNumber":1,"PageSize":10,"Filters":[{"field":"Name","operator":"contains","value":"1"},{"field":"Name","operator":"contains","value":"2"}],"logic":"or"}
```
  ![filtrelenmiş](https://github.com/ufukgulec/PaginationWithActionFilter/assets/51711890/80c3bc84-3c94-4235-8872-e66bf661812a)
## Action Filter kullanma nedeni
> [!IMPORTANT]
> Sayfalama ve filtreleme için PagingModel sınıfını Query'den almamız gerekiyorsa [FromQuery] kullanılır. 
```cs
[HttpGet("GetAll")]
public IActionResult GetAll([FromQuery]PagingModel pagingModel)
{
    DumpContext dumpContext = new DumpContext();

    return Ok(dumpContext.GetAll(pagingModel));
}
```
PagingModel'i action filter'dan yakalamasaydım metoda parametre olarak ekleyecektim ve Swagger'da aşağıdaki gibi gözükecekti.

![image](https://github.com/ufukgulec/PaginationWithActionFilter/assets/51711890/ba43e8dd-04bd-4bf0-89c7-7a6684af66dd)
> [!IMPORTANT]
> PagingModel sınıfını action filter ile yakalamak için ya sınıfın üstüne yada metodun üstüne action filter'ı belirtmemiz gerekiyor.
>  FilteringAttribute'tu da Program.cs'de Scoped olarak servise eklememiz gerekiyor.
```cs
[HttpGet("GetAll")]
[ServiceFilter(typeof(FilteringAttribute))]
public IActionResult GetAll()
{
    DumpContext dumpContext = new DumpContext();

    return Ok(dumpContext.GetAll(PagingModel));
}
```
PagingModel'i action filter'da yakalayınca metoda parametre olarak eklemeye gerek kalmadı ve Swagger'da aşağıdaki gibi gözüküyor.

![image](https://github.com/ufukgulec/PaginationWithActionFilter/assets/51711890/f85813fc-b2d1-46ce-958a-f727eab41796)

## İletişim

İletişim için orhanufukgulec@gmail.com adresine e-posta gönderin.

  
