## Introduction
This API aims to manage devices database


### Persistence layer
For this project, an inMemory database was created to run all CRUD processes

API Methods:
- `Device.GetAll` - finds all Devices
- `Device.GetById` - find the device by id
- `Device.GetByBrand` - find the list of device by brand name
- `Device.Create` - inserts a given device
- `Device.Update` - updates a given device
- `Device.Delete` - deletes a given device

### Web layer

**Devices endpoints**

- GETALL `/get` - returns all comments
- GETById `/get/{deviceId}` - returns comment by id
- GETByBrand `/getbybrand/{brandName}` - returns comment by id
- POST `/add` - creates a new comment
- PUT `/update` - updates a comment
- DELETE `/delete/{deviceId}` - deletes a comment by id

