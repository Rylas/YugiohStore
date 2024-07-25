CREATE database CardStoreDB;

USE CardStoreDB;

CREATE TABLE Account (	
	ID INT PRIMARY KEY IDENTITY (1,1),
	Name NVARCHAR(100) NOT NULL,
	Password NVARCHAR(1000) NOT NULL,
	Gender bit,
	Type INT NOT NULL DEFAULT 0 -- 1: admin, 2: staff, 3: customer
);

CREATE TABLE ProductCategory (
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL
);

CREATE TABLE Product (
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Sản phẩm mới',
	image_link TEXT NOT NULL,
	idCategory INT NOT NULL,
	price INT NOT NULL DEFAULT 0,
	quantity INT NOT NULL DEFAULT 1,
	status BIT NOT NULL DEFAULT 1,
	FOREIGN KEY (idCategory) REFERENCES ProductCategory(id)
);
CREATE TABLE Bill (
	id INT IDENTITY PRIMARY KEY,
	DateBook DATETIME NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATETIME,
	userID INT,
	totalAmount INT NOT NULL DEFAULT 0,
	status BIT NOT NULL DEFAULT 0, -- 1: đã thanh toán là 0: chưa thanh toán
	FOREIGN KEY (userID) REFERENCES Account(id),
);

CREATE TABLE BillDetails (
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idProduct INT NOT NULL,
	quantity INT NOT NULL DEFAULT 0,
	FOREIGN KEY (idBill) REFERENCES Bill(id),
	FOREIGN KEY (idProduct) REFERENCES Product(id)
);

INSERT INTO Account
VALUES (N'admin', N'admin', 1, 1);

INSERT INTO Account
VALUES (N'staff', N'staff', 1, 2);

INSERT INTO Account
VALUES (N'customer', N'customer', 1, 3);

INSERT INTO ProductCategory
VALUES (N'Hộp thẻ bài');

INSERT INTO ProductCategory
VALUES (N'Gói thẻ bài');

INSERT INTO ProductCategory
VALUES (N'Phụ kiện');

INSERT INTO Product
VALUES (N'Gói Thẻ Bài Yugioh Battles Of Legend: Terminal Revenge Booster Pack - BLTR - Chính Hãng Konami
', 'https://product.hstatic.net/200000593381/product/dsc09613_copy10_771b0e29e6b4432b88a15c3e890e2a2c_grande.jpg', 2, 94900, 100, 1);

INSERT INTO Product
VALUES (N'Hộp Thẻ Bài Yugioh Realm Of Light Structure Deck - SDLI 2024 Chính Hãng Konami
', 'https://product.hstatic.net/200000593381/product/dsc09453_copy3_22fceaae5cbe40b9a9bf07d5f615b868_grande.jpg', 1, 299000, 100, 1);

INSERT INTO Product
VALUES (N'Súc Sắc Yugioh Battles Of Legend: Chapter 1 - BLC1 - Chính Hãng Konami
', 'https://product.hstatic.net/200000593381/product/suc_sac_blc1_092d425b27b44b47ac5dc72756a30b8e_grande.jpg', 3, 39000, 100, 1);

INSERT INTO Product
VALUES (N'Hộp Thẻ Bài Yugioh Legacy Of Destruction Booster Box - LEDE - Chính Hãng Konami
', 'https://product.hstatic.net/200000593381/product/dsc09181_copy6_4be6045d86074404a4fe33736fa12631_grande.jpg', 1, 1990000, 100, 0);

INSERT INTO Product
VALUES (N'Gói Thẻ Bài Yugioh 25th Anniversary Rarity Collection II Booster Pack - RA02 - Chính Hãng Konami
', 'https://product.hstatic.net/200000593381/product/dsc09420_copy6_c065669e1ef0496abb18727623b8fab7_master.jpg', 2, 199000, 100, 1);

INSERT INTO Bill
VALUES (GETDATE(), NULL, 3, 0, 0);

INSERT INTO BillDetails
VALUES (1, 1, 1);

INSERT INTO BillDetails
VALUES (1, 2, 1);

INSERT INTO BillDetails
VALUES (1, 3, 1);

