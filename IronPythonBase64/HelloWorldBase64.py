import base64

originalString = str(originalString)

print("Orjinal metin: " + originalString)

encodedString = base64.b64encode(originalString.encode()).decode()
print("Şifreli metin: " + encodedString)

decodedString = base64.b64decode(encodedString).decode()
print("Şifresi açık metin: " + decodedString)

encodedString, decodedString