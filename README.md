# Battleship

Podczas tworzenia projektu chciałem zastosować DDD. 
Gra jest reprezenstowana przez
+ listę ShipConstraints, która zawiera informacją ile statków poszczególnych długości każdy z graczy ma do dyspozycji
+ GameGrid, każdego z graczy. GameGrid jest strukturą 2D złożoną z GameGridCell. Każda cella zawiera swój State oraz informacją jaki statek się na niej znajduje. State zawiera informację czy statek się na nim znajdujący został trafiony, lub czy ta komórka jest już trafiona-zpudłowana, lub w ogóle jeszcze nieodkryta.
+ Size, czyli rozmiar planszy.

GameHost ma za zadanie przeprowadzić daną mu grę. Korzysta on z zasad gry, o których jedynie musi wiedzieć jaki interfejs implementują. Ma to na celu umożliwić unit testing i dodawnie nowych reguł. 

GameFeed to logi i informacje jakie poszczególne ruchy wykonał każdy z graczy.

Do stworzenia gry wykorzystałem pattern z Builderem. Ma on za zadanie zbudować grę z podanymi paramterami, czyli przygotować statki i rozmieścić je na planszach.

Jest sporo rzeczy, które można by było tutaj usprawnić np. zastąpienie prymitywnych typów przez ValueObject lub może przemyśleć lepiej strukturę obiektu Game, ale na tyle akurat starczyło mi czasu.

Zasymulowana gra zwracana jest przez API. Obiekt taki zawiera początkowe rozmieszczenie statków każdego gracza oraz listę "ruchów" jakie wykonali oraz jaki był rezultat gry.
Dane te pokazywane są we froncie w Angularze jako taki mini film, który można nawet pauzować :)

We froncie trzeba by było przede wszystkim podzielić poszczególne segmenty na osobne komponenty, ale z braku czasu nie udało mi się tego zrobić :(


![image](https://user-images.githubusercontent.com/28758721/116444170-bd34b780-a854-11eb-8f53-9435c1e231af.png)
