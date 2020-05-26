import xml.sax
from scapy.all import *
import unicodedata

class MovieHandler( xml.sax.ContentHandler ):
   def __init__(self):
      self.CurrentData = ""
      self.version = ""
      self.chksum = ""
      self.dst = ""
      self.payload = ""
   # Call when an element starts
   def startElement(self, tag, attributes):
      self.CurrentData = tag
      if tag == "protocol":
         title = attributes["title"]
         print "Title:", title

   # Call when an elements ends
   def endElement(self, tag):
      global dst_v
      global chksum_v
      global payload_v
      if self.CurrentData == "version":
         print "version:", self.version
      elif self.CurrentData == "chksum":
         print "chksum:", self.chksum
         chksum_v = self.chksum
      elif self.CurrentData == "dst":
         print "dst:", self.dst
         dst_v = self.dst
      elif self.CurrentData == "payload":
         print "payload:", self.payload
         payload_v = self.payload
      self.CurrentData = ""

   # Call when a character is read
   def characters(self, content):
      if self.CurrentData == "version":
         self.version = content
      elif self.CurrentData == "chksum":
         self.chksum = content
      elif self.CurrentData == "dst":
         self.dst = content
      elif self.CurrentData == "payload":
         self.payload = content
  
if ( __name__ == "__main__"):

   # create an XMLReader
   parser = xml.sax.make_parser()
   # turn off namepsaces
   parser.setFeature(xml.sax.handler.feature_namespaces, 0)

   # override the default ContextHandler
   Handler = MovieHandler()
   parser.setContentHandler( Handler )
   
   parser.parse("my_XML.xml")
   payload_v = payload_v.encode('ascii','ignore')
   send(IP(dst=dst_v,chksum=int(chksum_v))/TCP()/payload_v)




