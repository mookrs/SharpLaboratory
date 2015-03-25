#coding: utf-8
import os, arcpy

if not os.path.exists('raster'):
    os.mkdir('raster')

rasterType = "FLOAT"
dir_path = os.path.dirname(os.path.abspath(__file__))
file_paths = [f for f in os.listdir('.') if os.path.isfile(f) and f.endswith(".txt")]

for file_path in file_paths:
    sub_dir_path = file_path[0:4]
    inASCII = os.path.join(dir_path, file_path)
    outRaster = os.path.join(dir_path, 'raster', file_path[0:-4])
    arcpy.ASCIIToRaster_conversion(inASCII, outRaster, rasterType)