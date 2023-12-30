# Domain Models

## Menu 🍕

This model is for Menu a Aggreate root.

```csharp
class Menu 
{
    Menu Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection(MenuSection section);
}
```

```json
{
    "id" : "guid",
    "name" : "string",
    "description" : "string",
    "averageRating" : 4.5,
    "sections" : [
        {
            "id" : "guid",
            "name" : "string",
            "description" : "starters",
            "items": [
                {
                    "id" : "guid",
                    "name" : "string",
                    "description" : "string",
                    "price": 0
                }
            ]
        }
    ],
    "createDateTime" : "datetime",
    "createdBy": "string",
    "modifyDateTime" : "datetime",
    "modifydBy": "string",
    "hostId" : "guid",
    "dinnerIds" :[
        "guid",
        "guid",
    ],
    "menuReviewIds" : [
        "guid",
        "guid",
    ],
    "deletedDateTime" : "datetime",
    "deletedBy": "string",
}
```
