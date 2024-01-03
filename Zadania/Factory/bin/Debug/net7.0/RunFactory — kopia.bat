@echo off
cls
echo Uruchamianie programu Factory...

.\Factory.exe "D:\Programowanie\UJ\Lab_C#\CSLabs\Zadania\BeerProcessor\bin\Debug\net7.0\BeerProcessor.dll;Piwo dla Jacka" "D:\Programowanie\UJ\Lab_C#\CSLabs\Zadania\SandwichProcessor\bin\Debug\net7.0\SandwichProcessor.dll;Kanapka dla Władka" "D:\Programowanie\UJ\Lab_C#\CSLabs\Zadania\BeerProcessor\bin\Debug\net7.0\BeerProcessor.dll; Piwo dla Władka" > output.txt

echo.
pause
