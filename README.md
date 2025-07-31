# Survivor API

ASP.NET Core Web API projesi olan **Survivor API**, yarışmacılar (Competitors) ve kategoriler (Categories) arasında ilişkilendirme yapan basit bir CRUD uygulamasıdır. Proje Entity Framework Core ile **Code First** yaklaşımına göre tasarlanmıştır.


## Projeye Genel Bakış

Bu proje, temel CRUD işlemlerini RESTful API yapısında gerçekleştirmek üzere geliştirilmiştir. Aşağıdaki işlemler yapılabilir:

- Yeni kategori ve yarışmacı oluşturma
- Kategori ve yarışmacı güncelleme
- Kategori ve yarışmacı silme (soft delete)
- Belirli bir kategori veya yarışmacıyı görüntüleme

---

## Teknolojiler

- **.NET 8 / ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server**
- **Code First Migration**
- **Dependency Injection**
- **Model Binding / Validation**


## Veritabanı Yapısı


| Alan           | Tip      | Açıklama                  |
| -------------- | -------- | ------------------------- |
| `Id`           | int      | Birincil anahtar (PK)     |
| `Name`         | string   | Kategori adı              |
| `CreatedDate`  | datetime | Oluşturulma zamanı        |
| `ModifiedDate` | datetime | Son güncellenme zamanı    |
| `IsDeleted`    | bool     | Silinmiş mi (soft delete) |


## Competitors Tablosu


| Alan           | Tip      | Açıklama                   |
| -------------- | -------- | -------------------------- |
| `Id`           | int      | Birincil anahtar (PK)      |
| `FirstName`    | string   | Yarışmacının adı           |
| `LastName`     | string   | Yarışmacının soyadı        |
| `Age`          | int      | Yaş                        |
| `CategoryId`   | int      | Kategoriyle ilişkilendirme |
| `CreatedDate`  | datetime | Oluşturulma zamanı         |
| `ModifiedDate` | datetime | Son güncellenme zamanı     |
| `IsDeleted`    | bool     | Silinmiş mi (soft delete)  |


🔗 İlişki

Bir kategori → Birden fazla yarışmacıya sahip olabilir: (One-to-Many / Category - Competitors)



📡 API Endpointleri

🔸 CategoriesController

| HTTP Yöntemi | Endpoint               | Açıklama                                    |
| ------------ | ---------------------- | ------------------------------------------- |
| `POST`       | `/api/categories`      | Yeni bir kategori oluşturur                 |
| `PUT`        | `/api/categories?id=5` | Belirtilen ID’ye sahip kategoriyi günceller |
| `GET`        | `/api/categories/{id}` | ID’ye göre tek bir kategoriyi getirir       |
| `DELETE`     | `/api/categories?id=5` | Kategoriyi soft-delete ile siler            |



🔸 CompetitorsController

| HTTP Yöntemi | Endpoint                | Açıklama                                       |
| ------------ | ----------------------- | ---------------------------------------------- |
| `POST`       | `/api/competitors`      | Yeni bir yarışmacı oluşturur                   |
| `PUT`        | `/api/competitors/{id}` | Yarışmacıyı günceller                          |
| `GET`        | `/api/competitors/{id}` | ID’ye göre yarışmacıyı ve kategorisini getirir |
| `DELETE`     | `/api/competitors?id=3` | Yarışmacıyı soft-delete ile siler              |




