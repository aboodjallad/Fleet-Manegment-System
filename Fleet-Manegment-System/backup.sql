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
1	1	100	40	-74
\.


--
-- Data for Name: driver; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.driver (driverid, drivername, phonenumber) FROM stdin;
10	John Doe	555123456
11	abood	595793983
12	Alice Johnson	555654321
13	Jane Smith	555987654
15	erer	987654321
16	erer	987654321
17	erer	987654321
19	jehad	1234321
20	jehad	1234321
21	jehad	1234321
14	jodo	1234
9	Default	741
23	jehad	595793983
24	jehad	595793983
26	jojo	595793983
27	mutaz	123455555
2	ahmad	123456
\.


--
-- Data for Name: geofences; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.geofences (geofenceid, geofencetype, addeddate, strokecolor, strokeopacity, strokeweight, fillcolor, fillopacity) FROM stdin;
1	Circular	1596230400000	Red	1	2	Blue	1
2	Rectangular	1598918400000	Blue	1	3	Green	1
3	Polygon	1601510400000	Green	1	1	Yellow	0
\.


--
-- Data for Name: polygongeofence; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.polygongeofence (id, geofenceid, latitude, longitude) FROM stdin;
1	3	41	-73
2	3	39	-75
3	3	37	-77
\.


--
-- Data for Name: rectanglegeofence; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.rectanglegeofence (id, geofenceid, north, east, west, south) FROM stdin;
1	2	42	-72	-78	36
\.


--
-- Data for Name: routehistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.routehistory (routehistoryid, vehicleid, vehicledirection, status, vehiclespeed, recordtime, address, latitude, longitude) FROM stdin;
1	1	180	1	60 km/h	1596230400000	123 Main St	40	-74
2	2	90	0	50 km/h	1598918400000	456 Elm St	38	-75
3	3	270	1	70 km/h	1601510400000	789 Oak St	37	-76
6	1	123	a	12	123434	blus	-90	88
7	2	10	b	jhuhjbhjg	100000000	shjgjhvggjh	0	100000000
8	2	10	b	jhuhjbhjg	100000000	shjgjhvggjh	0	100000000
9	2	10	b	jhuhjbhjg	100000000	shjgjhvggjh	0	100000000
10	3	10	s	jhuhjbhjg	100000000	shjgjhvggjh	0	100000000
11	1	123	r	50	2545676879	Paltel General administration building, Rafidia , Nablus , Palestine	34	43
12	1	123	r	50	2545676879	Paltel General administration building, Rafidia , Nablus , Palestine	34	43
13	2	342423	w	123	1234567	Paltel General administration building, Rafidia , Nablus , Palestine	45	54
14	3	342423	w	123	1234567	Paltel General administration building, Rafidia , Nablus , Palestine	45	54
15	1	342423	w	123	1234567	Paltel General administration building, Rafidia , Nablus , Palestine	45	54
16	3	342423	w	123	1234567	Paltel General administration building, Rafidia , Nablus , Palestine	45	54
17	10	342423	w	123	1234567	Paltel General administration building, Rafidia , Nablus , Palestine	45	54
18	11	342423	w	123	1234567	Paltel General administration building, Rafidia , Nablus , Palestine	45	54
19	3	342423	w	123	1234567	Paltel General administration building, Rafidia , Nablus , Palestine	45	54
20	8	342423	w	123	1234567	Paltel General administration building, Rafidia , Nablus , Palestine	45	90
21	8	342423	w	123	1234567	Paltel General administration building, Rafidia , Nablus , Palestine	45	100
22	1	342423	w	123	1234567	Paltel General administration building, Rafidia , Nablus , Palestine	45	54
23	3	342423	w	123	1234567	Paltel General administration building, Rafidia , Nablus , Palestine	45	54
24	12	342423	w	123	1234567	Paltel General administration building, Rafidia , Nablus , Palestine	45	54
25	6	342423	w	123	1234567	Paltel General administration building, Rafidia , Nablus , Palestine	45	54
26	10	342423	w	123	1234567	Paltel General administration building, Rafidia , Nablus , Palestine	45	89
27	8	342423	w	123	1234567	Paltel General administration building, Rafidia , Nablus , Palestine	45	89
28	1	12	k	12	123456	sdfsdf	123	321
29	11	12	k	12	123456	sdfsdf	123	321
30	9	342423	w	123	1234567	Paltel General administration building, Rafidia , Nablus , Palestine	45	89
31	1	342423	w	123	1234567	Paltel General administration building, Rafidia , Nablus , Palestine	45	89
32	6	342423	w	123	1234567	Paltel General administration building, Rafidia , Nablus , Palestine	45	89
33	11	342423	w	123	1234567	Paltel General administration building, Rafidia , Nablus , Palestine	45	89
34	6	342423	w	123	1234567	Paltel General administration building, Rafidia , Nablus , Palestine	45	89
\.


--
-- Data for Name: vehicles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.vehicles (vehicleid, vehiclenumber, vehicletype) FROM stdin;
3	345678	Truck
1	1234	toto
5	0	
6	0	
8	0	
9	0	
10	12345654	Sport
11	567765	Sport
12	7896541	Sport
2	23456789	Sedan
\.


--
-- Data for Name: vehiclesinformations; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.vehiclesinformations (vehicleid, driverid, vehiclemake, vehiclemodel, purchasedate) FROM stdin;
\N	2	BMW	M5	8789465
9	11	k	k	1454556
6	12	Hondaaaaaa	M5	15989184
8	10	Hondaaaaaa	M5	15989184
\N	10	Hondaaaaaa	M5	15989184
\N	21	Honda	M5	1234678999
3	11	Hondaaaaaa	M55	15989184
3	11	Hondaaaaaa	M55	15989184
5	11	bmw	21002	123456
\.


--
-- Name: circlegeofence_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.circlegeofence_id_seq', 1, true);


--
-- Name: driver_driverid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.driver_driverid_seq', 27, true);


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

SELECT pg_catalog.setval('public.routehistory_routehistoryid_seq', 34, true);


--
-- Name: vehicles_vehicleid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.vehicles_vehicleid_seq', 12, true);


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

