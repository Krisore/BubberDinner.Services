# Domain Models

## Menu 🍕

This model is for Menu a Aggreate root.

### Behavior

```csharp
class Menu 
{
    Menu Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection(MenuSection section);
}
```

### Models

```json
{
    "id" : "guid",
    "name" : "string",
    "description" : "string",
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
    "hostId" : "guid",
    "dinnerIds" :[
        "guid",
        "guid",
    ],
    "menuReviewIds" : [
        "guid",
        "guid",
    ],
    "averageRating" : 4.5,
    "createDateTime" : "datetime",
    "createdBy": "string",
    "modifyDateTime" : "datetime",
    "modifydBy": "string",
    "deletedDateTime" : "datetime",
    "deletedBy": "string",
}
```
