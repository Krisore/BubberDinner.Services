# Create Menu

## Create Menu Request

```api
POST /hosts/{hostId}/menus
```

```json
"name" : "Yummy Menu",
"description" : "A menu with yummy food",
"sections" : [

    {
      "name" : "appetizer",
      "description" : "starters",
      "items" : [
        {
            "name" : "Fried Pickles",
            "description" : "Deep Fried Pickles"
        }
      ]
    }

]
```
