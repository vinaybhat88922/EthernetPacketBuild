import xml.etree.cElementTree as ET
import xlrd
loc="MyConfigScapy.xls"
xlshandler = xlrd.open_workbook(loc)
sheet0=xlshandler.sheet_by_index(0)

def ValueExtr(x,y):
	return sheet0.cell_value(x,y)
	
	
def XLStoXML():
	
	
	root = ET.Element("root")
	doc=ET.SubElement(root, "protocol ",title="IP")
	ET.SubElement(doc, "version").text = str(int(ValueExtr(0,1)))
	ET.SubElement(doc, "chksum").text = str(int(ValueExtr(1,1)))
	ET.SubElement(doc, "dst").text = str(ValueExtr(2,1))
	ET.SubElement(doc, "payload").text = str(ValueExtr(3,1))
	tree = ET.ElementTree(root)
	tree.write("my_XML.xml")
	

	
XLStoXML()