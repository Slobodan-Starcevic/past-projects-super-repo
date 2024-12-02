Pyspark app, ontwikkeld om op een VM in een prive VMware vSphere network omgeving te lopen. Onderdeel van een fullstack app waar mijn teamgenoten de front-en backend hebben gebouwd waarmee ik mijn spark script heb gekoppeld via een websocket. Het doel is om via de frontend een python script te uploaden, dat via de back-end bij Spark wordt afgeleverd en vervolgens wordt gedistribueerd naar 5 (of meer) worker-VM's. Deze verwerken het script parallel en sturen de resultaten terug naar de back-end/front-end. Ze sturen ook tussentijdse updates. Als extra heb ik bash scripts geschreven in Debian om processen te automatiseren voor mijn teamgenoten die minder bekend zijn met Debian of Spark. Deze scripts maken taken zoals het koppelen, verwijderen en herstarten van de Master en Worker nodes eenvoudiger.
Tech:
-Spark
-Python
-Websockets
-Debian VM (CLI-only)