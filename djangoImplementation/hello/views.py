import re
from django.shortcuts import render

# Create your views here.

from django.http import HttpResponse
from django.shortcuts import render

def home(request):
    return render(request,'hello/hello.html')

def index(request):
    return render(request, 'index.html')
def stream_llm_response(request):

    promt = "hello ollama say hi back to me and state thatthis is my response"

    ollama_endpoint =  "http://localhost:11434/api/generate"

    payload = {
            "model": "llama",
            "promt": promt,
            "stream": True
            }

