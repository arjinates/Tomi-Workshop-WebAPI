# Tomi 

## Proje Açıklaması

Bu proje, bir workshop çalışmasıdır ve temel amacı, efektif çalışan ve fonksiyonel bir yapıya sahip bir Shopping Cart projesi geliştirmektir. Proje, clean architecture mimarisi kullanılarak tasarlanmıştır ve CQRS ve MediatR tasarım desenleri kullanılmıştır. Proje, e-ticaret uygulamalarında sıkça kullanılan alışveriş sepeti işlevselliğini yerine getirmeyi hedeflemektedir.

Projenin bir diğer önemli özelliği, Mocking Frameworks kullanarak Unit Test yazmayı kolaylaştırmasıdır. Bu sayede, geliştirilen her bir bileşenin ve fonksiyonun test edilmesi mümkün olacak ve kod kalitesi artırılacaktır. Ayrıca, JWT token authentication kullanıldığından, kullanıcıların güvenliği ve gizliliği de önem taşıyor. Bu nedenle, proje geliştirilirken bu konuda özel önlemler alınmıştır.

Bir e-ticaret platformunun temel bir bileşeni olan projemiz kullanıcıların alışveriş deneyimini arttırmak için kullanılabilir. Projenin ana hedefleri arasında, ölçeklenebilir ve performanslı bir altyapı sunmak, kullanıcıların alışveriş sepeti işlemlerini yönetmelerine yardımcı olmak ve işlevselliği artırmak yer almaktadır.

Aynı zamanda workshop'da front-end ve mobil ile ilgilenen takım arkadaşlarımız bu back-end sistemini kullanarak uygulamalarını efektif şekilde geliştirmişlerdir. Onların projelerine erişmek için tıklayın: 

[Web](https://github.com/mustafablutt/shopping-cart.git)

[Mobile](https://github.com/CemTitor/shopping_cart_tom)

## Projede Kullanılan Teknolojiler

<p align="left"> 
  <a href="https://docs.microsoft.com/en-us/dotnet/csharp/" target="_blank" rel="noreferrer"> 
      <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" alt="csharp" width="40" height="40"/> 
  </a> 
  <a href="https://dotnet.microsoft.com/download/dotnet/6.0" target="_blank" rel="noreferrer"> 
      <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dotnetcore/dotnetcore-original.svg" alt=".NET Core 6.0" width="40" height="40"/> 
  </a>
  <a href="https://www.mongodb.com/" target="_blank" rel="noreferrer"> 
      <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/mongodb/mongodb-original-wordmark.svg" alt="MongoDB" width="40" height="40"/> 
  <a href="https://www.docker.com/" target="_blank" rel="noreferrer"> 
      <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/docker/docker-original-wordmark.svg" alt="Docker" width="40" height="40"/> 
  </a>
</p>

## Projede Kullanılan Paketler

MongoDB.Driver

Microsoft.AspNetCore.Identity
  
AspNetCore.Identity.MongoDbCore

MediatR;

AutoMapper
  
Microsoft.AspNetCore.Authorization;

AspNetCore.Authentication 

System.IdentityModel.Tokens.Jwt
  
## Proje Mimarisi

**Domain Layer** katmanı, uygulamanın çekirdek iş mantığından sorumludur ve herhangi bir dış bağımlılık içermez. Bu katmanda, uygulamanın iş kuralları, varlık sınıfları ve arayüzleri yer alır. Bu katmanı, bağımsızlığı sağlamak ve diğer katmanlarla olan etkileşimleri minimize etmek için mümkün olduğunca saf bir şekilde tasarladık.
  
**Infrastructure Layer** katmanı, uygulamanın dış dünyayla olan etkileşiminden sorumludur. Bu katman, veri depolama, harici servisler ve diğer araçlar gibi dış kaynaklara erişmek için kullanılır. Bu katman, Domain katmanına bağımlıdır.  Infrastructure katmanı, veri depolama, harici servisler ve diğer araçlara erişim için kullanıldığından, en az bağımsız katmanlardan biri. Bu katmanda, örneğin, veritabanı işlemleri, dosya işlemleri, harici API'lar gibi işlemler gerçekleştirdik.

**Application Layer** katmanı, uygulamanın kullanıcı arabirimi ve işlevselliği ile ilgilenir. Bu katman, kullanıcı taleplerini alır, iş mantığı kurallarını uygular ve sonuçları sunar. Bu katman Domain katmanına bağımlıdır. Domain katmanı içerisindeki iş kurallarını kullanır. Bu katmanda, kullanıcı taleplerini aldık, iş mantığı kuralları uyguladık ve sonuçları sunduk.
  
**Presentation Layer** Projemizin presentation katmanı, yani web api, kullanıcılarla etkileşim kurduğumuz arayüz katmanımızdır. Bu katman, kullanıcılardan gelen istekleri alır, ilgili servislere yönlendirir ve sonuçları kullanıcılara geri döndürür. Projemizde presentation katmanı, ASP.NET Core Web API kullanılarak oluşturulmuştur. Bu sayede, web api'nin özelliklerinden yararlanarak HTTP protokolüne uygun bir şekilde istek-cevap işlemleri yapılabilmektedir. Ayrıca, .NET Core 6.0'ın sunduğu gelişmiş özellikler de kullanılmıştır. Presentation katmanı, kullanıcı kimlik doğrulaması için JWT token authentication kullanmaktadır. Kullanıcıların güvenliği ve gizliliği çok önemli olduğundan, bu katmanda güvenlik konusuna özel bir önem verilmiştir.

## Authorize ve Token

Projemizde authorize için Bearer token kullanılmıştır. bir web API veya web servisine kimlik doğrulama yapmak için kullanılan bir güvenlik tokenıdır. Bu token, bir kullanıcının kimliğini doğrulamak için kullanılır ve bu sayede kullanıcıların yetkilendirilmiş işlemler yapmaları sağlanır. Authorize, ASP.NET Core tarafından sunulan bir yetkilendirme middleware'idir. Bu middleware'i projemizde alışveriş sepeti ve kupon işlemlerinde kullanmaktayız.

JWT (JSON Web Token), web uygulamaları arasında güvenli bir şekilde bilgi alışverişi yapmak için kullanılan bir standardı tanımlayan bir token formatıdır. Bu token'lar, bir kullanıcının kimliğini doğrulamak için kullanılan bilgileri (claim) içerir ve diğer uygulamalar arasında güvenli bir şekilde taşınabilirler. Biz bu claim içerisinde UserId bilgimizi sakladık ve login requestindeki response içerisinde tokena yer verdik

## Docker
  
Docker konteynerleştirme platformu, uygulamaların geliştirme ve dağıtım süreçlerini hızlandırmak için kullanılan bir teknolojidir. Docker sayesinde, uygulamaları farklı ortamlarda sorunsuz bir şekilde çalıştırmak ve yönetmek mümkün hale gelir.

## Design Patterns
### CQRS Pattern
  
CQRS, uygulamanın komutlarını (command) ve sorgularını (query) ayırmayı amaçlar. Pattern, uygulamanın karmaşıklığını azaltır ve ölçeklenebilirliği artırır. Bu patterni kullanmamızdaki amaç, uygulamalarda aynı veri kaynağına birden fazla sorgulama işlemi yapıldığında ortaya çıkan performans sorunlarını giderebilmektir. Bu sayede, ölçeklenebilirliği arttıyoruz ve uygulamanın performansını optimize ediyoruz. CQRS'i MediatR kütüphanesiyle birlikte kullandık. Bu kütüphane, CQRS tasarım desenine uygun şekilde, komut ve sorguları ayrı sınıflar halinde yazmayı ve uygulama içinde Mediator (aracı) olarak kullanmayı sağlar.
 
### Mediator Pattern

Mediator pattern, birbirleriyle doğrudan etkileşim kurmak yerine aracı bir nesne (mediator) aracılığıyla etkileşim kuran nesneler arasındaki bağı azaltmayı hedefler. Bu sayede nesneler arasındaki bağımlılıklar azaltılır, kod daha esnek ve bakımı kolay hale gelir. Projemizde de Mediator pattern kullanarak CQRS (Command and Query Responsibility Segregation) mimarisini uyguladık. Bu sayede komutların ve sorguların ayrı ayrı ele alınmasını, doğrudan nesneler arasındaki bağımlılıkların azaltılmasını ve kodun daha esnek hale gelmesini sağladık. MediatR kütüphanesini kullanarak, bu yapıyı uygulamamızda kullanabildik.
  
## Unit Tests
  
Proje dökümantasyonunun bu bölümünde, Coupons, Products ve ShoppingCarts servislerine ait Unit Testlerden bahsedeceğiz. Unit Testler, her bir servisin doğru çalıştığını ve beklenen sonuçları ürettiğini doğrulamak için kullanılır. Bu testler, yazılımın kalitesini artırmak, hataları tespit etmek ve geliştirme sürecini desteklemek için önemlidir.
  
### Coupons Servisi Unit Testleri

Coupons servisi için yazılan Unit Testler, kupon işlemlerinin doğru bir şekilde gerçekleştiğini kontrol eder. Senaryolar için gerekli giriş verileri sağlanır, servis çağrılır ve çıktıların beklenen sonuçlarla eşleşip eşleşmediği kontrol edilir.

Unit Testlerin başarılı olması, Coupons servisinin beklenen işlevleri yerine getirdiğini ve hata durumlarında doğru davranışı sergilediğini gösterir. Geliştirme sürecinde, yeni senaryolar eklenerek daha kapsamlı testler yazılabilir ve hataların önlenmesi sağlanabilir. 
  
### Products Servisi Unit Testleri

Products servisi için yazılan Unit Testler, ürün işlemlerinin doğru bir şekilde gerçekleşip gerçekleşmediğini kontrol etmemizi sağlar. Senaryolar test edilir, servis çağrılır ve çıktıların beklenen sonuçlarla eşleşip eşleşmediği kontrol edilir.

Unit Testlerin başarılı olması, Products servisinin beklenen işlevleri yerine getirdiğini ve hata durumlarında doğru davranışı sergilediğini gösterir. Yeni ürün işlemleri eklendiğinde veya mevcut işlemler değiştirildiğinde, test senaryoları güncellenerek servisin hala doğru çalıştığından emin olunabilir.
  
### ShoppingCarts Servisi Unit Testleri

ShoppingCarts servisi unit testleri servisin beklendiği gibi çalışıp çalışmadığını kontrol eder. Test senaryoları, ürün ekleme, ürün silme, sepeti temizleme gibi temel işlemleri kapsar. Her bir senaryo için gerekli giriş verileri sağlanır, servis çağrılır ve çıktıların beklenen sonuçlarla eşleşip eşleşmediği kontrol edilir.  

Test senaryolarımızı gözden geçirin, eklemek istedikleriniz varsa pull request atmaktan çekinmeyin! Feedback'lerinizi bekliyoruz.
  
## Endpoints 
Fonksiyonel ve geliştirmeye açık endpointlerimiz:
  
![image](https://github.com/arjinates/TomiProject/assets/92892806/d6e12e4a-38a8-4abf-a4be-fc7b52c87d3e)
