# Yapay Zeka Destekli SIEM Loglarından Otomatik Olay Özetleme Sistemi

## Proje Hakkında

Bu proje, SIEM (Security Information and Event Management) loglarının yapay zeka destekli olarak otomatik şekilde analiz edilmesini sağlayan bir güvenlik otomasyon sistemidir.

Sistem; kullanıcıdan alınan SIEM log kayıtlarını analiz ederek olay özeti, saldırı türü, risk skoru ve çözüm önerileri üretmektedir. Ayrıca analiz sonuçları otomatik olarak veri tabanına kaydedilmekte ve kullanıcıya e-posta bildirimi gönderilmektedir.

Bu proje sayesinde manuel log analiz süreci azaltılmış, güvenlik operasyon süreçleri hızlandırılmış ve olay yönetimi daha merkezi hale getirilmiştir.

---

# Kullanılan Teknolojiler

Projede aşağıdaki teknolojiler kullanılmıştır:

- Google Forms
- Google Sheets
- n8n Workflow Automation
- Airtable Database
- Groq AI
- Gmail Integration
- Threat Intelligence Structure

# Sistem Mimarisi

Sistem aşağıdaki adımlardan oluşmaktadır:

1. Kullanıcı Google Forms üzerinden SIEM logunu gönderir.
2. Veriler otomatik olarak Google Sheets’e aktarılır.
3. Google Sheets Trigger workflow’u başlatır.
4. n8n workflow sistemi çalışır.
5. Incident ve User kayıtları Airtable’a kaydedilir.
6. AI Agent node’u logu Groq AI modeline gönderir.
7. Yapay zeka modeli saldırı türünü ve risk skorunu oluşturur.
8. Threat Intelligence kaydı oluşturulur.
9. Incident kaydı güncellenir.
10. Kullanıcıya otomatik e-posta gönderilir.

# Gelecek Çalışmalar

Projeye ileride aşağıdaki özellikler eklenebilir:

- Gerçek SIEM platform entegrasyonu
- Gerçek zamanlı saldırı tespiti
- Dashboard sistemi
- IOC veri tabanı entegrasyonu
- Makine öğrenmesi destekli analiz
- Çoklu AI model desteği
- Web tabanlı yönetim paneli

# Güvenlik Notu

Bu repository içerisinde:
- API key’leri,
- Airtable token bilgileri,
- Gmail bağlantı bilgileri,
- Groq API anahtarları

paylaşılmamaktadır.

# Sonuç

Bu proje sayesinde SIEM log analiz süreçleri yapay zeka destekli şekilde otomatik hale getirilmiştir. Sistem güvenlik operasyon ekiplerinin manuel analiz yükünü azaltmakta ve olay müdahale süreçlerini hızlandırmaktadır.

Proje, yapay zeka destekli güvenlik otomasyonu alanında örnek bir çalışma olarak geliştirilmiştir.