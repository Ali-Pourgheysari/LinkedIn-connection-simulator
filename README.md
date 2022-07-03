# LinkedIn Connection simulator
this application is used to simulate a connection between people on LinkedIn. You give the application a JSON file as input that includes people registered on LinkedIn before with their information like:
* Id
* Name
* date of birth
* university location
* field of study
* workplace
* specialties
* connection Id (the id of the person you are connected with)

<p align="center">
    <img src=".\screenshot\2 inter json file.png" width="200" higth="50" >
</p>

## Sign up
You have to enter the information mentioned above to sign up. Then your Id number will be generated for you so you have to save it.

<p align="center">
    <img src=".\screenshot\3 sign up form.png" width="100" higth="250" >
</p>

## Login
You have to enter your Id number and name to log in.

<p align="center">
    <img src=".\screenshot\1 login form.png" width="100" higth="150" >
</p>

## Connection suggestions
As soon as you log in, you will be able to see the suggestions of connections you can make. these connections are based on the information you entered before. Each piece of information have a weight that will be used to calculate the similarity between you and suggested connections.

<p align="center">
    <img src=".\screenshot\5 suggestions.png" width="100" higth="300" >
</p>

After you see the suggestions, you can click on the name of the person you want to connect with and by clicking on the button "Follow" you connect with the person then the list refreshes and you can see the new suggestions.

<p align="center">
    <img src=".\screenshot\6 connected.png" width="800" higth="600" >
</p>

<div dir="rtl" align='right'>

  در این پروژه قرار هست عملکرد برنامه لینکدین را شبیه سازی نماییم.
  توضیحات کامل پروژه و راهنمایی پیاده سازی در فایل مستند پروژه در همین ریپوزیتوری قابل مشاهده هست.

در کنار فایل مستند توضیحات پروژه یک فایل نمونه ورودی(users.json) به فرمت جی‌سان به شما داده شده است.

  دقت کنید که این دیتاست ورودی داده شده تستی است و تعداد آن کم است. برای ارائه دیتاست بزرگتری که صحت و کیفیت برنامه شما چک شود، داده‌میشود.
  
  همانطور که در صورت پروژه هم گفته شده شما خودتان می‌توانید دیتاست با مقدارهای منطقی درست کنید و آن را با بقیه بچه ها به اشتراک بگذارید و نمره امتیازی دریافت کنید.

علاوه بر تولید دستی جنریتور برای دیتاست ها ، یکی از کتابخانه‌های تولید دیتاست ورودی منطقی، کتابخانه فیکر پایتون است. از لینک زیر می‌توانید توضیحات بیشتری درموردآن مشاهده کنید.

+ [آشنایی مقدماتی کتابخانه faker در پایتون](https://www.geeksforgeeks.org/python-faker-library/)

 ### سایر بخش های نمره دهی علاوه بر موارد گفته شده در مستند پروژه
+ کامیت بندی صحیح پروژه و ارسال درست روی گیت و برنچ جدید
+ کلاس بندی صحیح و درست
+ کدنویسی تمیز (نام گذاری درست متغیرها، طولانی نبودن مین برنامه، برای هرکار متفاوت تابع و کلاس مخصوص به خود داشتن و...)
+ تفکر شما در مورد روش حل مسئله( در زمان ارائه باید توضیح دهید.)
+ فرستادن توضیح مرتبه زمانی بخش  "پیدا کردن کانکشن ‌ها" در یک برنچ جداگانه
+ به راه حل ها و الگوریتم های خلاقانه نمره ویژه تعلق خواهد گرفت!


</div>
