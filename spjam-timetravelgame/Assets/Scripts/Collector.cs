using UnityEngine;
using System.Collections;

public class Collector : MonoBehaviour {
	public int m_Score = 0;

	public void Collect(CollectValue value) {
		m_Score += value.m_Value;
		if (value.m_NextLevel != -1) {
			Application.LoadLevel(value.m_NextLevel);
		}
	}
}
