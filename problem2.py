sumo = 0
limit = 4000000
f1, f2, f3 = 0, 1, 0
while f3 < limit:
    f3 = f1 + f2
    if f3%2 == 0:
        sumo = sumo + f3
    f2,f1 = f3,f2
print sumo
