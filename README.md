# Веб-API - информация о видеоиграх

## Возможности веб-API:
* добавление игры в базу данных;
* обновление игры в базе данных;
* удаление игры в базе данных по id;
* получение данных об игре по id;
* получение всех игр хранящихся в базе данных;
* получение списка игр по заданному жанру.

## Пример добавления данных об игре:
```json
{
  "name": "Subway Surfers",
    "studioDeveloper": "SYBO Games",
    "genres": [
      "Платформер",
      "EndlessRunning"
    ]
}
```
