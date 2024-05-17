--
-- PostgreSQL database dump
--

-- Dumped from database version 16.2
-- Dumped by pg_dump version 16.2

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: circlegeofence; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.circlegeofence (
    id bigint NOT NULL,
    geofenceid bigint,
    radius bigint,
    latitude integer,
    longitude integer
);


ALTER TABLE public.circlegeofence OWNER TO postgres;

--
-- Name: circlegeofence_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.circlegeofence_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.circlegeofence_id_seq OWNER TO postgres;

--
-- Name: circlegeofence_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.circlegeofence_id_seq OWNED BY public.circlegeofence.id;


--
-- Name: driver; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.driver (
    driverid bigint NOT NULL,
    drivername character varying,
    phonenumber bigint
);


ALTER TABLE public.driver OWNER TO postgres;

--
-- Name: driver_driverid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.driver_driverid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.driver_driverid_seq OWNER TO postgres;

--
-- Name: driver_driverid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.driver_driverid_seq OWNED BY public.driver.driverid;


--
-- Name: geofences; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.geofences (
    geofenceid bigint NOT NULL,
    geofencetype character varying,
    addeddate bigint,
    strokecolor character varying,
    strokeopacity integer,
    strokeweight integer,
    fillcolor character varying,
    fillopacity integer
);


ALTER TABLE public.geofences OWNER TO postgres;

--
-- Name: geofences_geofenceid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.geofences_geofenceid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.geofences_geofenceid_seq OWNER TO postgres;

--
-- Name: geofences_geofenceid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.geofences_geofenceid_seq OWNED BY public.geofences.geofenceid;


--
-- Name: polygongeofence; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.polygongeofence (
    id bigint NOT NULL,
    geofenceid bigint,
    latitude integer,
    longitude integer
);


ALTER TABLE public.polygongeofence OWNER TO postgres;

--
-- Name: polygongeofence_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.polygongeofence_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.polygongeofence_id_seq OWNER TO postgres;

--
-- Name: polygongeofence_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.polygongeofence_id_seq OWNED BY public.polygongeofence.id;


--
-- Name: rectanglegeofence; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.rectanglegeofence (
    id bigint NOT NULL,
    geofenceid bigint,
    north integer,
    east integer,
    west integer,
    south integer
);


ALTER TABLE public.rectanglegeofence OWNER TO postgres;

--
-- Name: rectanglegeofence_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.rectanglegeofence_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.rectanglegeofence_id_seq OWNER TO postgres;

--
-- Name: rectanglegeofence_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.rectanglegeofence_id_seq OWNED BY public.rectanglegeofence.id;


--
-- Name: routehistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.routehistory (
    routehistoryid bigint NOT NULL,
    vehicleid bigint,
    vehicledirection integer,
    status character(1),
    vehiclespeed character varying,
    recordtime character varying,
    address character varying,
    latitude integer,
    longitude integer
);


ALTER TABLE public.routehistory OWNER TO postgres;

--
-- Name: routehistory_routehistoryid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.routehistory_routehistoryid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.routehistory_routehistoryid_seq OWNER TO postgres;

--
-- Name: routehistory_routehistoryid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.routehistory_routehistoryid_seq OWNED BY public.routehistory.routehistoryid;


--
-- Name: vehicles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.vehicles (
    vehicleid bigint NOT NULL,
    vehiclenumber bigint,
    vehicletype character varying
);


ALTER TABLE public.vehicles OWNER TO postgres;

--
-- Name: vehicles_vehicleid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.vehicles_vehicleid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.vehicles_vehicleid_seq OWNER TO postgres;

--
-- Name: vehicles_vehicleid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.vehicles_vehicleid_seq OWNED BY public.vehicles.vehicleid;


--
-- Name: vehiclesinformations; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.vehiclesinformations (
    vehicleid bigint,
    driverid bigint DEFAULT 999,
    vehiclemake character varying(255),
    vehiclemodel character varying(255),
    purchasedate bigint
);


ALTER TABLE public.vehiclesinformations OWNER TO postgres;

--
-- Name: vehiclesinformations_driverid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.vehiclesinformations_driverid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.vehiclesinformations_driverid_seq OWNER TO postgres;

--
-- Name: vehiclesinformations_driverid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.vehiclesinformations_driverid_seq OWNED BY public.vehiclesinformations.driverid;


--
-- Name: circlegeofence id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.circlegeofence ALTER COLUMN id SET DEFAULT nextval('public.circlegeofence_id_seq'::regclass);


--
-- Name: driver driverid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.driver ALTER COLUMN driverid SET DEFAULT nextval('public.driver_driverid_seq'::regclass);


--
-- Name: geofences geofenceid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.geofences ALTER COLUMN geofenceid SET DEFAULT nextval('public.geofences_geofenceid_seq'::regclass);


--
-- Name: polygongeofence id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.polygongeofence ALTER COLUMN id SET DEFAULT nextval('public.polygongeofence_id_seq'::regclass);


--
-- Name: rectanglegeofence id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.rectanglegeofence ALTER COLUMN id SET DEFAULT nextval('public.rectanglegeofence_id_seq'::regclass);


--
-- Name: routehistory routehistoryid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.routehistory ALTER COLUMN routehistoryid SET DEFAULT nextval('public.routehistory_routehistoryid_seq'::regclass);


--
-- Name: vehicles vehicleid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.vehicles ALTER COLUMN vehicleid SET DEFAULT nextval('public.vehicles_vehicleid_seq'::regclass);


--
-- Data for Name: circlegeofence; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.circlegeofence (id, geofenceid, radius, latitude, longitude) FROM stdin;
\.


--
-- Data for Name: driver; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.driver (driverid, drivername, phonenumber) FROM stdin;
29	jehad	595793983
30	mutaz	987654321
31	mohammed	595796654
\.


--
-- Data for Name: geofences; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.geofences (geofenceid, geofencetype, addeddate, strokecolor, strokeopacity, strokeweight, fillcolor, fillopacity) FROM stdin;
\.


--
-- Data for Name: polygongeofence; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.polygongeofence (id, geofenceid, latitude, longitude) FROM stdin;
\.


--
-- Data for Name: rectanglegeofence; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.rectanglegeofence (id, geofenceid, north, east, west, south) FROM stdin;
\.


--
-- Data for Name: routehistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.routehistory (routehistoryid, vehicleid, vehicledirection, status, vehiclespeed, recordtime, address, latitude, longitude) FROM stdin;
37	14	789	s	14	123456789	Paltel General administration building, Rafidia , Nablus , Palestine	0	0
38	15	12	A	12 K/H	1234567	Paltel General administration building, Rafidia , Nablus , Palestine	0	0
39	16	5	D	80 k/h	1234567	Paltel General administration building, Rafidia , Nablus , Palestine	0	0
\.


--
-- Data for Name: vehicles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.vehicles (vehicleid, vehiclenumber, vehicletype) FROM stdin;
14	0	Sport
15	0	SUV
16	0	Sport
\.


--
-- Data for Name: vehiclesinformations; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.vehiclesinformations (vehicleid, driverid, vehiclemake, vehiclemodel, purchasedate) FROM stdin;
14	29	BMW	M5	1234678999
15	30	Honda	Civic	12346845412154
16	31	VW	Golf	3456764333
\.


--
-- Name: circlegeofence_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.circlegeofence_id_seq', 1, true);


--
-- Name: driver_driverid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.driver_driverid_seq', 31, true);


--
-- Name: geofences_geofenceid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.geofences_geofenceid_seq', 3, true);


--
-- Name: polygongeofence_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.polygongeofence_id_seq', 3, true);


--
-- Name: rectanglegeofence_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.rectanglegeofence_id_seq', 1, true);


--
-- Name: routehistory_routehistoryid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.routehistory_routehistoryid_seq', 39, true);


--
-- Name: vehicles_vehicleid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.vehicles_vehicleid_seq', 16, true);


--
-- Name: vehiclesinformations_driverid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.vehiclesinformations_driverid_seq', 1, false);


--
-- Name: circlegeofence circlegeofence_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.circlegeofence
    ADD CONSTRAINT circlegeofence_pkey PRIMARY KEY (id);


--
-- Name: driver driver_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.driver
    ADD CONSTRAINT driver_pkey PRIMARY KEY (driverid);


--
-- Name: geofences geofences_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.geofences
    ADD CONSTRAINT geofences_pkey PRIMARY KEY (geofenceid);


--
-- Name: polygongeofence polygongeofence_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.polygongeofence
    ADD CONSTRAINT polygongeofence_pkey PRIMARY KEY (id);


--
-- Name: rectanglegeofence rectanglegeofence_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.rectanglegeofence
    ADD CONSTRAINT rectanglegeofence_pkey PRIMARY KEY (id);


--
-- Name: routehistory routehistory_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.routehistory
    ADD CONSTRAINT routehistory_pkey PRIMARY KEY (routehistoryid);


--
-- Name: vehicles vehicles_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.vehicles
    ADD CONSTRAINT vehicles_pkey PRIMARY KEY (vehicleid);


--
-- Name: circlegeofence circlegeofence_geofenceid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.circlegeofence
    ADD CONSTRAINT circlegeofence_geofenceid_fkey FOREIGN KEY (geofenceid) REFERENCES public.geofences(geofenceid);


--
-- Name: polygongeofence polygongeofence_geofenceid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.polygongeofence
    ADD CONSTRAINT polygongeofence_geofenceid_fkey FOREIGN KEY (geofenceid) REFERENCES public.geofences(geofenceid);


--
-- Name: rectanglegeofence rectanglegeofence_geofenceid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.rectanglegeofence
    ADD CONSTRAINT rectanglegeofence_geofenceid_fkey FOREIGN KEY (geofenceid) REFERENCES public.geofences(geofenceid);


--
-- Name: routehistory routehistory_vehicleid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.routehistory
    ADD CONSTRAINT routehistory_vehicleid_fkey FOREIGN KEY (vehicleid) REFERENCES public.vehicles(vehicleid);


--
-- Name: vehiclesinformations vehiclesinformations_driverid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.vehiclesinformations
    ADD CONSTRAINT vehiclesinformations_driverid_fkey FOREIGN KEY (driverid) REFERENCES public.driver(driverid) ON DELETE SET NULL;


--
-- Name: vehiclesinformations vehiclesinformations_vehicleid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.vehiclesinformations
    ADD CONSTRAINT vehiclesinformations_vehicleid_fkey FOREIGN KEY (vehicleid) REFERENCES public.vehicles(vehicleid) ON DELETE SET NULL;


--
-- PostgreSQL database dump complete
--

