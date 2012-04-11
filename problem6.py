sumo = 0
proo = 0
for s in xrange(1,101):
    sumo += s
    proo = proo + s**2
sumo = sumo**2

print abs(sumo-proo)
