using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Observable
{
    void addObserver(Observer observer);

    void removeObserver(Observer observer);

    void notifyObservers();
}
