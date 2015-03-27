#coding: utf-8
"""
    分年度存放生成的 raster 数据。
"""
import os, arcpy

if not os.path.exists('raster'):
    os.mkdir('raster')

for i in xrange(1993, 2014):
    sub_dir = os.path.join('raster', str(i))
    if not os.path.exists(sub_dir):
        os.mkdir(sub_dir)

rasterType = "FLOAT"
dir_path = os.path.dirname(os.path.abspath(__file__))
file_paths = [f for f in os.listdir('.') if os.path.isfile(f) and f.endswith(".txt")]

for file_path in file_paths:
    sub_dir_path = file_path[0:4]
    inASCII = os.path.join(dir_path, file_path)
    outRaster = os.path.join(dir_path, 'raster', sub_dir_path, file_path[0:-4])
    arcpy.ASCIIToRaster_conversion(inASCII, outRaster, rasterType)