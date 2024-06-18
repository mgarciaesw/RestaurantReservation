-- Adminer 4.8.1 PostgreSQL 16.2 dump
-- Create with adminer a database "customer" and then import this file

\connect "customer";

DROP TABLE IF EXISTS "Customers";
DROP SEQUENCE IF EXISTS "Customer_Id_seq";
CREATE SEQUENCE "Customer_Id_seq" INCREMENT  MINVALUE  MAXVALUE  CACHE ;

CREATE TABLE "public"."Customers" (
    "Id" integer DEFAULT nextval('"Customer_Id_seq"') NOT NULL,
    "FirstName" text NOT NULL,
    "LastName" text NOT NULL,
    "Email" text NOT NULL,
    "TotalNumberOfReservations" integer NOT NULL,
    "LastRestaurantReserved" text,
    CONSTRAINT "Customer_pkey" PRIMARY KEY ("Id")
) WITH (oids = false);


-- 2024-06-18 11:08:32.216815+00
