-- =========================================
-- StockHouse - Initial Seed Script (Categories, Products, Inventories)
-- Safe to run multiple times (idempotent).
-- =========================================
BEGIN;

-- 1) CATEGORIES ----------------------------------------------------
-- NOTE: Adjust column list if your Categories table has required extra columns.
-- Assumes: public."Categories" ("Id" uuid PK, "Name" varchar/text UNIQUE or at least not null)
-- If "Categories" table name or schema is different, rename below accordingly.
INSERT INTO public."Categories" ("Id", "Name")
VALUES
  ('a2fa6d7e-2f5d-4b5e-b6a1-6d1c7bbf0a01', 'Electronics'),
  ('b3b23c55-3b0e-4a3e-9a9a-2b0d0c9a7b02', 'Home & Kitchen'),
  ('c4c4c4c4-8d6b-4c1a-9d1f-9b8a7c6d5e03', 'Fashion'),
  ('d5e6f7a8-1b2c-4d5e-8f90-1a2b3c4d5e04', 'Grocery'),
  ('e6f7a8b9-2c3d-4e5f-9012-3b4c5d6e7f05', 'Toys & Games')
ON CONFLICT ("Id") DO NOTHING;

-- 2) PRODUCTS ------------------------------------------------------
-- Fixed UUIDs so the data is deterministic across environments.
-- Schema (given): Id, Name, Description, Sku, CategoryId, Uom, IsActive, Price, CreatedTime, UpdatedTime, CreatedBy, UpdatedBy, IsDeleted
INSERT INTO public."Products"
("Id","Name","Description","Sku","CategoryId","Uom","IsActive","Price","CreatedTime","UpdatedTime","CreatedBy","UpdatedBy","IsDeleted")
VALUES
-- Electronics
('f06fbe89-9bd1-4d01-bbac-3675f1f850f4','Wireless Mouse','Ergonomic wireless mouse with 2.4GHz receiver','ELEC-001','a2fa6d7e-2f5d-4b5e-b6a1-6d1c7bbf0a01','pcs',true,350.00, NOW(), NULL, NULL, NULL, false),
('60c8803f-0ebf-4da4-8039-7574d25a030c','Bluetooth Headphones','Noise-cancelling over-ear headphones','ELEC-002','a2fa6d7e-2f5d-4b5e-b6a1-6d1c7bbf0a01','pcs',true,1200.00, NOW(), NULL, NULL, NULL, false),

-- Home & Kitchen
('94598dff-f890-4d68-88f5-45c25de7dc09','Electric Kettle','1.7L stainless steel fast-boil kettle','HOME-001','b3b23c55-3b0e-4a3e-9a9a-2b0d0c9a7b02','pcs',true,450.00, NOW(), NULL, NULL, NULL, false),
('c3dc8e62-259a-43be-8d46-832251480c97','Non-stick Pan Set','3-piece non-stick frying pan set','HOME-002','b3b23c55-3b0e-4a3e-9a9a-2b0d0c9a7b02','set',true,800.00, NOW(), NULL, NULL, NULL, false),

-- Fashion
('c5cb96e8-2cfe-488a-b5bc-130062f34dad','Denim Jacket','Classic blue denim jacket for all seasons','FASH-001','c4c4c4c4-8d6b-4c1a-9d1f-9b8a7c6d5e03','pcs',true,950.00, NOW(), NULL, NULL, NULL, false),
('91de8cb7-09f7-43f1-bc98-c7cc2926fd27','Sneakers','Comfortable everyday sneakers, unisex design','FASH-002','c4c4c4c4-8d6b-4c1a-9d1f-9b8a7c6d5e03','pair',true,650.00, NOW(), NULL, NULL, NULL, false),

-- Grocery
('db95c790-07ec-41c2-a781-4132628b7908','Organic Olive Oil','Extra virgin olive oil, 1L bottle','GROC-001','d5e6f7a8-1b2c-4d5e-8f90-1a2b3c4d5e04','bottle',true,180.00, NOW(), NULL, NULL, NULL, false),
('145b7827-aaf0-432d-9eb2-f1517ce1bc9e','Whole Wheat Pasta','High-fiber pasta, 500g pack','GROC-002','d5e6f7a8-1b2c-4d5e-8f90-1a2b3c4d5e04','pack',true,40.00, NOW(), NULL, NULL, NULL, false),

-- Toys & Games
('e0dce8ce-fb16-4ceb-ba8b-4062004e8a8a','Lego Starter Set','Creative building blocks set','TOY-001','e6f7a8b9-2c3d-4e5f-9012-3b4c5d6e7f05','box',true,750.00, NOW(), NULL, NULL, NULL, false),
('ce8d248d-bad8-42cf-b028-ed9f17422ee8','RC Car','Rechargeable remote control car','TOY-002','e6f7a8b9-2c3d-4e5f-9012-3b4c5d6e7f05','pcs',true,500.00, NOW(), NULL, NULL, NULL, false)
ON CONFLICT ("Id") DO NOTHING;

-- 3) INVENTORIES ---------------------------------------------------
-- One stock row per product above (fixed UUIDs & quantities).
INSERT INTO public."Inventories"
("Id","ProductId","Quantity","IsActive","CreatedTime","UpdatedTime","CreatedBy","UpdatedBy","IsDeleted")
VALUES
('932f3aa3-e338-4008-a917-9ae507ba5b55','f06fbe89-9bd1-4d01-bbac-3675f1f850f4',  85.00, true, NOW(), NULL, NULL, NULL, false),
('f982bc0c-339a-418c-833f-eb9725dafc5e','60c8803f-0ebf-4da4-8039-7574d25a030c',  62.00, true, NOW(), NULL, NULL, NULL, false),

('63dcc13f-6d95-402e-8505-bc8245c34932','94598dff-f890-4d68-88f5-45c25de7dc09', 120.00, true, NOW(), NULL, NULL, NULL, false),
('e42d3016-e352-46b6-9952-075bf09ed0c2','c3dc8e62-259a-43be-8d46-832251480c97',  47.00, true, NOW(), NULL, NULL, NULL, false),

('ab1e6a81-5373-41a4-a329-3cb6b8b0a2b8','c5cb96e8-2cfe-488a-b5bc-130062f34dad',  33.00, true, NOW(), NULL, NULL, NULL, false),
('8a8d560f-4d5b-47e5-a58c-87073d8ca12b','91de8cb7-09f7-43f1-bc98-c7cc2926fd27',  75.00, true, NOW(), NULL, NULL, NULL, false),

('559a7779-418f-4b9d-b0c1-91e31755e1ee','db95c790-07ec-41c2-a781-4132628b7908', 210.00, true, NOW(), NULL, NULL, NULL, false),
('ad2f10e3-89d5-4328-8956-2bd4eb78087f','145b7827-aaf0-432d-9eb2-f1517ce1bc9e', 350.00, true, NOW(), NULL, NULL, NULL, false),

('1caacfa5-5eac-407d-bc18-6805633d98c1','e0dce8ce-fb16-4ceb-ba8b-4062004e8a8a',  18.00, true, NOW(), NULL, NULL, NULL, false),
('4d9a57a7-a75f-4ccf-bfc6-1670e8214707','ce8d248d-bad8-42cf-b028-ed9f17422ee8',  58.00, true, NOW(), NULL, NULL, NULL, false)
ON CONFLICT ("Id") DO NOTHING;

COMMIT;
-- =========================================
