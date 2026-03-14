# ZenBlogServer

ZenBlogServer, modern bir blog platformunun sunucu tarafı ihtiyaçları için geliştirilmiş **ASP.NET Core Web API** projesidir. İçerik üretimi ve yönetimini merkeze alan bu yapı; kullanıcı kimlik doğrulama, blog yönetimi, yorum akışı ve iletişim modüllerini tek bir servis katmanında toplar.

## Projenin Amacı

ZenBlogServer’ın temel amacı, blog tabanlı dijital ürünlerde en sık ihtiyaç duyulan backend senaryolarını sürdürülebilir bir mimari ile sağlamaktır:

- İçerik tarafında blog ve kategori ilişkilerini yönetmek
- Kullanıcı kayıt/giriş süreçlerini güvenli şekilde işletmek
- Yorum ve alt yorum hiyerarşisini yönetmek
- İletişim formları, sosyal bağlantılar ve “about” gibi sayfa bileşenlerini API üzerinden yönetilebilir yapmak
- Yeni modüllerin minimum etkiyle sisteme eklenebileceği bir uygulama iskeleti sunmak

## Neyi Çözüyor?

ZenBlogServer, özellikle aşağıdaki ürün ihtiyaçlarını hedefler:

- **İçerik yönetimi:** Editör/panel tarafından blog yazılarının oluşturulması, güncellenmesi ve silinmesi
- **Kategorizasyon:** Blogların kategori bazlı filtrelenebilmesi
- **Etkileşim:** Kullanıcı yorumlarının ve alt yorumların işlenmesi
- **Kimlik & güvenlik:** JWT tabanlı erişim kontrolü
- **Yönetim modülleri:** Mesaj, iletişim bilgisi, sosyal medya, hakkımızda gibi alanların API seviyesinde yönetimi

## Öne Çıkan Teknik Özellikler

- **JWT Authentication & Authorization**
  - Token tabanlı kimlik doğrulama ve endpoint bazlı yetkilendirme yaklaşımı
- **CQRS + MediatR**
  - Komut (write) ve sorgu (read) süreçlerinin ayrıştırılması
  - Handler tabanlı use-case implementasyonu
- **FluentValidation**
  - Giriş doğrulamalarının merkezi ve tutarlı biçimde yönetilmesi
- **Global Exception Middleware**
  - Validation ve beklenmeyen hataların standart JSON çıktılarla dönülmesi
- **Entity Framework Core + SQL Server**
  - Kalıcılık katmanında güçlü ORM desteği
- **ASP.NET Identity**
  - AppUser/AppRole tabanlı kimlik altyapısı
- **AutoMapper**
  - DTO/entity dönüşümlerinde temiz kod yaklaşımı
- **OpenAPI + Scalar API Reference (Development)**
  - Geliştirme sürecinde endpoint keşfi ve hızlı test kolaylığı

## Mimari Yaklaşım

Proje, sorumlulukları net ayrılmış katmanlı bir mimari izler:

### 1) Domain Katmanı (`Core/ZenBlog.Domain`)

İş alanının merkezini oluşturan entity’leri içerir:

- `Blog`, `Category`
- `Comment`, `SubComment`
- `Message`
- `About`, `ContactInfo`, `Social`
- `AppUser`, `AppRole`

Bu katman, teknolojiden bağımsız olarak iş modelini tanımlar.

### 2) Application Katmanı (`Core/ZenBlog.Application`)

Use-case’lerin çalıştığı ana katmandır:

- Feature bazlı organizasyon (Blogs, Categories, Users, Messages vb.)
- CQRS komut/sorgu modelleri
- MediatR handler implementasyonları
- FluentValidation kuralları
- Endpoint tanımları
- Mapping profilleri

Bu yapı sayesinde her iş kabiliyeti dikey bir feature olarak gelişebilir.

### 3) Persistence Katmanı (`Infrastructure/ZenBlog.Persistance`)

Veri erişimi ve altyapı detaylarını barındırır:

- `AppDbContext` ve EF Core migration’ları
- Repository & Unit of Work implementasyonları
- Identity store entegrasyonu
- JWT üretimi/doğrulaması için servisler
- Audit interceptor ile değişiklik takibi

### 4) API Katmanı (`Presantation/ZenBlog.API`)

Uygulamanın dış dünyaya açılan kapısıdır:

- Program pipeline konfigurasyonu
- CORS, Authentication, Authorization middleware sıralaması
- Exception handling middleware
- Endpoint registration
- OpenAPI/Scalar entegrasyonu

## Endpoint ve Erişim Modeli

API endpoint’leri `/api` altında gruplanır. Genel model:

- **Anonim erişime açık:** kullanıcı kayıt ve giriş işlemleri
- **Yetki gerektiren:** içerik ve yönetim modüllerinin büyük bölümü

### Başlıca modüller

- Users
- Blogs
- Categories
- Comments
- SubComments
- Messages
- ContactInfos
- Socials
- Abouts

## İstek Yaşam Döngüsü (Yüksek Seviye)

1. İstek API katmanına gelir.
2. İlgili endpoint komut/sorguyu MediatR üzerinden Application katmanına iletir.
3. Validation davranışı devreye girer.
4. Handler iş kuralını işletir, Persistence katmanıyla veri erişimi yapar.
5. Sonuç standart response modeliyle döner.
6. Hata varsa global middleware tarafından uygun HTTP cevabına çevrilir.

Bu akış, hataların merkezi yönetimi ve iş akışlarının tutarlılığı için kritik bir avantaj sağlar.

## Kod Organizasyonu Yaklaşımı

Projede feature-first bir dizilim kullanılır. Her feature altında tipik olarak şunlar bulunur:

- `Commands`
- `Queries`
- `Handlers`
- `Validators`
- `Mappings`
- `Result`
- `Endpoints`

Bu yaklaşım, hem okuma kolaylığı hem de uzun vadeli bakım açısından güçlü bir temel sunar.

## Teknik Notlar

- CORS politikası `http://localhost:4200` origin’i için tanımlıdır.
- Pipeline içinde özel exception middleware kullanılır.
- Validation hataları standart bir sonuç modeliyle döndürülür.
- Audit interceptor, veri değişikliklerinin merkezi izlenmesine yardımcı olur.
- Geliştirme ortamında OpenAPI ve Scalar referansı devrededir.

## Kısa Yol Haritası

- Role-based authorization kurallarının detaylandırılması
- API versiyonlama stratejisinin eklenmesi
- Gözlemlenebilirlik (structured logging, tracing, metrics) iyileştirmeleri
- Test kapsamının (unit/integration) genişletilmesi
- Rate limiting ve güvenlik katmanlarının güçlendirilmesi

---

ZenBlogServer, blog ürünlerinin backend tarafında temiz mimariyi, modüler geliştirmeyi ve ölçeklenebilir API tasarımını bir araya getiren güçlü bir temel sağlar.
