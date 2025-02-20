using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppETA25.Automation.Session7
{
    internal class ActionClassHomeworkWIP
    {
        /*Similar cu ce am facut astazi, tema va necesita interactiunea cu UI-ul prin mecanismele disponibile in cardul clasei "Actions":
          Pentru pagina de "Interactions > Dragable":
            1. Creati 4 teste (cate unul pentru fiecare tab) in care sa:
          Toate testele trebuie sa aiba asserturi care sa verifice pozitia chenarelor!

            2. "Simple" tab: 
          Mutati chenarul "Drag me" in coltul stanga sus al elementului "//div[@class=\"dragable-container\"]" (vezi in DOM-ul paginii)
          
            3."Axis Restricted" tab:
            Mutati chenarele "Only X" si "Only Y" pentru a fi aliniate central (pe X sau pe Y) cu elementul "//h1[@class=\"text-center\"]" (vezi in DOM-ul paginii; este titlul "Dragabble")
            
            4."Container Restricted" tab:
            Mutati containerul copil sa fie centrat in containerul parinte "//div[@id=\"containmentWrapper\"]"
            
            5."Cursor Style" tab:
            Aici e tema extra daca vreti sa va jucati cu modul in care elementele sunt draggable si locatia cursorului relativa la element.
            Puteti implementa diferite teste care sa mute elementele si sa calculeze pozitia lor relativa la locul unde s-a facut drag&drop.
            
        
        TIPS & TICKS:
            Bazat pe sesiunea de azi, mecanismul este asemanator:
            Utilizarea unui Action class pentru a efectua secventa de actiuni:
            MoveByOffset()
            MoveToElement()
            MoveToLocation()
            ClickAndHold()
            Release()
            Build()
            Perform()
            Extra puteti folosi si metodele built-in de drag&drop:
            DragAndDrop()
            DragAndDropToOffset()
            Pentru a putea calcula coordonatele unui element, interfata de IWebElement ne ofera acces la urmatoarele:
            Location - coordonatele coltului stanga sus al elementului curent relativ la viewport (colt stanga sus - exact ce explicam in curs legat de originea coordonatelor X si Y)
            Size - dimensiunea elementului curent (latime si inaltime)*/

    }
}
