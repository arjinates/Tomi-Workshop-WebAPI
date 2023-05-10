# TomiProject
#Tomi 

##PROJE AÇIKLAMASI

Bu proje, bir workshop çalışmasıdır ve temel amacı, efektif çalışan ve fonksiyonel bir yapıya sahip bir Shopping Cart projesi geliştirmektir. Proje, clean architecture mimarisi kullanılarak tasarlanmıştır ve CQRS ve MediatR tasarım desenleri kullanılmıştır. Bu proje, e-ticaret uygulamalarında sıkça kullanılan alışveriş sepeti işlevselliğini yerine getirmeyi hedeflemektedir.

Projenin bir diğer önemli özelliği, Mocking Frameworks kullanarak Unit Test yazmayı kolaylaştırmasıdır. Bu sayede, geliştirilen her bir bileşenin ve fonksiyonun test edilmesi mümkün olacak ve kod kalitesi artırılacaktır. Ayrıca, JWT token authentication kullanıldığından, kullanıcıların güvenliği ve gizliliği de önem taşıyor. Bu nedenle, proje geliştirilirken bu konuda özel önlemler alınmıştır.

Bir e-ticaret platformunun temel bir bileşeni olan projr kullanıcıların alışveriş deneyimini arttırmak için kullanılabilir. Projenin ana hedefleri arasında, ölçeklenebilir ve performanslı bir altyapı sunmak, kullanıcıların alışveriş sepeti işlemlerini yönetmelerine yardımcı olmak ve işlevselliği artırmak yer almaktadır.

Aynı zamanda workshop'da front-end ve mobil ile ilgilenen takım arkadaşlarımız bu back-end sistemini kullanarak uygulamalarını efektif şekilde geliştirmişlerdir. Onların projelerine erişmek için tıklayın: 
..
..

##PROJEDE KULLANILAN TEKNOLOJİLER

-C# programlama dili
-.NET Core 6.0
-MongoDB veritabanı
-AutoMapper kütüphanesi
-MediatR kütüphanesi
-Microsoft Jwt tokens kütüphanesi
-MongoDbCore kütüphanesi
-AspNetCore.Authentication kütüphanesi
-Docker konteynerleştirme platformu

##PROJE MİMARİSİ

-Domain Katmanı: Bu katman, uygulamanın çekirdek iş mantığından sorumludur ve herhangi bir dış bağımlılık içermez. Bu katmanda, uygulamanın iş kuralları, varlık sınıfları ve arayüzleri yer alır. Bu katmanı, bağımsızlığı sağlamak ve diğer katmanlarla olan etkileşimleri minimize etmek için mümkün olduğunca saf bir şekilde tasarladık.
-Infrastructure Katmanı: Bu katman, uygulamanın dış dünyayla olan etkileşiminden sorumludur. Bu katman, veri depolama, harici servisler ve diğer araçlar gibi dış kaynaklara erişmek için kullanılır. Bu katman, Domain katmanına bağımlıdır.  Infrastructure katmanı, veri depolama, harici servisler ve diğer araçlara erişim için kullanıldığından, en az bağımsız katmanlardan biri. Bu katmanda, örneğin, veritabanı işlemleri, dosya işlemleri, harici API'lar gibi işlemler gerçekleştirdik.
-Application Katmanı: Bu katman, uygulamanın kullanıcı arabirimi ve işlevselliği ile ilgilenir. Bu katman, kullanıcı taleplerini alır, iş mantığı kurallarını uygular ve sonuçları sunar. Bu katman, hem Domain hem de Infrastructure katmanlarına bağımlıdır. Katman uygulamanın kullanıcı arabirimi ve işlevselliği ile ilgili olduğundan, en çok bağımlılık içeren katmandır. Bu katmanda, kullanıcı taleplerini aldık, iş mantığı kuralları uyguladık ve sonuçları sunduk.

##Dizayn Patternleri
comments

##Canlı 
![image](https://github.com/arjinates/TomiProject/assets/92892806/8924a4c3-8996-4001-840a-43b1dd94a58f)

##Geliştiriciler
