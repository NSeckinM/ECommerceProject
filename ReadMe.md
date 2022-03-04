# ECommerce 

Clean Architecture mimarisinden yararlanýlarak bir e-ticaret sitesi geliþtirilmeye çalýþýlmýþtýr.Repository pattern ve Service yapýsý kullanýlmýþ.
Veri tabaný olarak PostgreSql kullanýlmýþtýr. Üyelik sistemi için identity package kullanýlmýþtýr .
Admin paneli için "seckin@xyz.com" e-mail adresi ve þifre="Seckin123_" olarak tanýmlanmýþtýr. Her türlü ekleme silme ve güncelleme kýsýmlarý için bu panel kullanýlmaktadýr.
Ayrýca bu projede codefirst olarak ilerlenmiþtir ve baþlangýç için örnek veriler seed edilmiþtir. 
Daha çok ayrýntý için projeyi indirerek deneyebilirsiniz.

### EF Commands
**Default project: src\Infrastructure**

Update-Database -Context AppIdentityDbContext

Update-Database -Context ApplicationDbContext 

komutlarý projenin çalýþýr hale gelmesi için yeterlidir.

## Ana sayfa
<img src="https://github.com/NSeckinM/ECommerceProject/blob/master/Src/ApplicationCore/images/as1.png"/>

##AdminPanel-Ürün Ekle/Sil/Düzenle

<img src="https://github.com/NSeckinM/ECommerceProject/blob/master/Src/ApplicationCore/images/U1.png"/>

##AdminPanel-Kategori Ekle/Sil/Düzenle

<img src="https://github.com/NSeckinM/ECommerceProject/blob/master/Src/ApplicationCore/images/K1.png"/>

##AdminPanel-Marka Ekle/Sil/Düzenle

<img src="https://github.com/NSeckinM/ECommerceProject/blob/master/Src/ApplicationCore/images/M1.png"/>

##Database

<img src="https://github.com/NSeckinM/ECommerceProject/blob/master/Src/ApplicationCore/images/Db.png"/>



