# znamkamarada
Let's try to save at least a part of 400 000 000 CZK from the state budget of the Czech Republic

# web
https://znamkamarada.cz/

Tato repository vznikla na základě podnětu Tomáše Vondráčka 
https://www.linkedin.com/posts/tomas-vondracek-801737b_ve%C5%99ejn%C3%A1-v%C3%BDzva-rozhodli-jsme-se-%C5%BEe-p%C5%99%C3%ADst%C3%AD-activity-6623954244326215680-CCLn/
abychom měli místo kam začít ukládat dokumenty, psát komentáře a sdílet issues.

Zkusme to. Třeba to dopadne. 
A pokud ne, tak se aspoň nemusíme stydět, že jsme to ani nezkusili.


# NNPŘ (naivní návrh pilotního řešení)

Včera večer jsem přemýšlel o službě která bude ukládat informaci o zakoupené známce pro LicencePlate (znamkamarada.Services.Registration) a hlavně validovat platnou znamku pro danou LicencePlate. Myšlenky jsou uložené v této repository
https://github.com/Richard004/znamkamarada/ 

Logiku registrace a validace mám vytaženou v class library zde
https://github.com/Richard004/znamkamarada/tree/master/src/znamkamarada.Services.Library 

Ta je pak použita například v jednoduchém WebApi, kde už žádná logika (kromě routingu a uložených connection stringů) není.
https://github.com/Richard004/znamkamarada/tree/master/src/znamkamarada.Services.Validation.WebApi 

Ale pro lepší škálovatelnost bych možná použi nějakou AzureFunction. 
Toto si zvolíme dle infrastruktury, ve Azure FunctionApp ani WebApi žádná světoborná logika nebude.

Fyzickou presistenci uložené licence navrhuji uložit do Azure Table storage
 https://github.com/Richard004/znamkamarada/blob/master/src/znamkamarada.Services.Library/Services/VignettePersistenceService.cs
což mám pouze rozdělané.

Ale je to obecná implementace rozhraní 
https://github.com/Richard004/znamkamarada/blob/master/src/znamkamarada.Services.Library/Interfaces/IVignettePersistenceService.cs 
které pouze umí (bude umět) super efektivně vytáhnout max rok staré záznamy pro vybranou LicencePlate

Logika validace bez ohledu na persistenci bude zde
https://github.com/Richard004/znamkamarada/blob/master/src/znamkamarada.Services.Library/Services/VignetteValidationService.cs 
Zde se vyhledají záznamy pro LicencePlate porovnají se ty zaplacené intervaly s dotazovaným datem.

Nástroje na validaci a sanitizaci LicencePlate vč. státu registrace jsou zde
https://github.com/Richard004/znamkamarada/blob/master/src/znamkamarada.Services.Library/Tools/LicencePlateTools.cs 


Považuji to za nejednodušší možnou ale plně funkční, škálovatelnou a zabezpečitelnou implementaci.
Toto vše jsou myšlenky které nabízím k nahlédnutí.
Můžete je ignorovat nebo zahodit dle libosti.

