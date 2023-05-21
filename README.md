# QiwiTest1
Solution for Receipt Writer test problem

# Build instructions
.Net version 7.0

Build and launch QiwiTest1 project for a console demo.

QiwiTest1 does not reference any external dependencies and can be built and run right away.

TestProject1 contains Nuget package dependencies and requires access to Nuget repository.

# Commentary
Because meaning of each digit is determined by it's position counting from the right side, but in verbal notation numbers are written from left to right, I opted to accumulate resulting lexemes in reverse order so that I would reverse the list in the end.
I opted for parsing the input string into decmial type instead of analyzing character-by-character because by my evaluation the performance compromise is compensated by simplification of the algorithm. Especially in some intricate cases, such as placement of commas or in case of long succession of zeros.
When extracting methods I tried to minimize side effects.
	
# What I would do differently had I additional time
Maybe the algorithm could be simplified by analyzing the number starting from the higher digits, because decimal type simplifies it a great deal. Also this approach could allow for using of LinkedList to accumulate lexemes.
	
# Инструкции по сборке
Версия .Net 7.0; 

Собрать и запустить проект QiwiTest1 для консольного демо.

Проект QiwiTest1 не содержит внешних зависимостей и может быть собран и запущен сразу.

Проект TestProject1 содержит зависимости от Nuget пакетов и соответственно требует доступа к Nuget репозиторию.

# Комментарии
Поскольку разряд каждого знака в числовой записи определяется его позицией справа налево, а при словесной записи разряды записываются в порядке слева направо, я решил накапливать лексемы в обратном порядке с тем чтобы при завершении обратить этот список.
Я выбрал перевод входной строки в тип decimal вместо посимвольного разбора, потому что посчитал что компромисс по производительности компенсируется сравнительной простотой алгоритма, особенно в некоторых тонких моментах реализации. Таких как расстановка запятых или несколько следующих друг за другом нулей.
При выделении методов я руководствовался минимизацией побочного эфекта
	
# Что бы я изменил если бы у меня было больше времени
Возможно алгоритм можно упростить, используя разбор начиная с бОльшего разряда, так как тип представление в числовом типе предоставляет такую возможность. Также при таком подходе для накопления лексем можно использовать LinkedList.
	


